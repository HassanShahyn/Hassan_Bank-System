using Microsoft.AspNetCore.Mvc;
using HassanBank.Domain.Interfaces; // مكان الإنترفيس بتاعك

namespace HassanBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyoutController : ControllerBase
    {
        // 1. بنعرف السيستم إننا محتاجين خدمة الباي أوت
        private readonly IBuyoutService _buyoutService;

        public BuyoutController(IBuyoutService buyoutService)
        {
            _buyoutService = buyoutService;
        }

        // 2. أول زرار تجريبي: ترحيب
        [HttpGet("CheckSystem")]
        public IActionResult GetStatus()
        {
            return Ok("Welcome to Hassan Wealth & Freedom Platform 🚀.. System is Online!");
        }

        // هنا هنضيف زرار الحسابات الخطوة الجاية
    }
}