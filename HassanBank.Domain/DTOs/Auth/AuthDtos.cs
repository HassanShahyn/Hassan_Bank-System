using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.DTOs.Auth
{
    public class RegisterDto
    {
        [Required,MaxLength(100)]
        public string FullName { get; set; } =string.Empty;
        [Required,EmailAddress]
        public string Email {  get; set; } =string.Empty;
        [Required,MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required,MaxLength(14),MinLength(14)]
        public string NationalId { get; set; } = string.Empty;
    }
    public class LoginDto
    {
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
    public class AuthModel
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}
