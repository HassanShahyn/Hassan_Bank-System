using HassanBank.Domain;
using HassanBank.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace HassanBank.Infrastructure.Persistence
{
    // ده الكلاس اللي بيمثل الداتا بيز في الكود
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<CreditCard> creditCards { get; set; }
        public DbSet<FinancialProfile> FinancialProfiles { get; set; }
        public DbSet<Interaction>  Interactions { get; set; }
        public DbSet<Opportunity>  Opportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // انا هنا بقوله خلي بالك ان address not entity its value object
            base.OnModelCreating(modelBuilder);

            // 1. التعامل مع الـ Value Objects (العناوين)
            // العناوين بيتم تخزينها كأعمدة داخل جدول العميل وليس جداول منفصلة
            // التصحيح: غيرنا الاسم لـ entity عشان نمنع التعارض
            modelBuilder.Entity<Client>(entity =>
            {
                // 1. Value Objects (دمج العناوين)
                entity.OwnsOne(c => c.HomeAddress);
                entity.OwnsOne(c => c.BusinessAddress);

                // 2. Data Integrity (حماية البيانات)
                entity.HasIndex(c => c.NationalId).IsUnique(); // ممنوع تكرار الرقم القومي
                entity.Property(c => c.NationalId)
                      .HasMaxLength(14)
                      .IsFixedLength(); // حجز 14 حرف بالظبط (تحسين أداء)
            });
            // (TPT)--Table per type دي بتمنع nulls in database
            // =========================================================
            // 2. TPT Strategy (The Core of our Product Architecture)
            // =========================================================
            // Parent Table
            modelBuilder.Entity<ClientProduct>().ToTable("Products");

            // Child Tables (Inherits ID from Product automatically)
            modelBuilder.Entity<Loan>().ToTable("Loans");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");

            modelBuilder.Entity<FinancialProfile>()
                .HasOne(fp => fp.Client)
                .WithOne(c => c.FinancialProfile)
                .HasForeignKey<FinancialProfile>(fp => fp.ClientId);

            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Interactions)
                .HasForeignKey(i => i.ClientId);

            modelBuilder.Entity<Opportunity>()
                .HasOne(O => O.Client)
                .WithMany(c => c.Opportunities)
                .HasForeignKey(o => o.ClientId);

            modelBuilder.Entity<ClientProduct>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                   .SelectMany(t => t.GetProperties())
                   .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                // Fix: SetPrecision and SetScale must be called separately on IMutableProperty
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
    }
}