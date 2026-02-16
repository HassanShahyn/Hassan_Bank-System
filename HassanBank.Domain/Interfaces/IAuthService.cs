using System.Threading.Tasks;
using HassanBank.Domain.DTOs.Auth; // ✅ ده الـ Namespace الجديد للـ DTOs داخل الـ Domain

namespace HassanBank.Domain.Interfaces
{
    public interface IAuthService
    {
        // دالة تسجيل مستخدم جديد
        Task<AuthModel> RegisterAsync(RegisterDto model);

        // دالة تسجيل الدخول واستلام التوكن
        Task<AuthModel> GetTokenAsync(LoginDto model);
    }
}