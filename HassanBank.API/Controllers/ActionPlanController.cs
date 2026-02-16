using HassanBank.Domain.DTOs;
using HassanBank.Domain.Entities;
using HassanBank.Domain.Enums;
using HassanBank.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HassanBank.API.Controllers
{
    public class ActionPlanController : ControllerBase
    {
        private readonly IActionPlanService _actionPlanService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ActionPlanController> _Logger;

        public ActionPlanController
            (
            IActionPlanService actionPlanService,
            UserManager<ApplicationUser> userManager,
            ILogger<ActionPlanController> logger
            )
        {
            _actionPlanService = actionPlanService;
            _userManager = userManager;
            _Logger = logger;
        }

        public IActionResult CheckEligibility([FromBody] ClientProfileDto clientProfile, [FromQuery] ProductType productType)
        {
            _Logger.LogInformation("Start eligibility check for Product: {ProductType} with Income: {Income}", productType, clientProfile.MonthlyIncome);
            if(clientProfile.MonthlyIncome <= 0)
            {
                return BadRequest("should be Monthly Income  GeatherThan 0.0");
            }
            try
            {
                var criteria = GetCriteriaForProduct(productType);
                var result = _actionPlanService.GenerateRoadmap(clientProfile , criteria);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                _Logger.LogError(ex, "Error occurred during eligibility check.");
                return StatusCode(500, "حدث خطأ داخلي في النظام، يرجى المحاولة لاحقاً.");
            }
            
        }
        public async Task<IActionResult> GetMyRoundmap([FromQuery] ProductType targetProduct)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();
                _Logger.LogInformation("User {UserId} requesting roadmap for {Product}", user.Id, targetProduct);

                var currentProfile = new ClientProfileDto
                {
                    MonthlyIncome = user.MonthlyNetSalary,
                    TotalExistingIstallments = user.TotalExistingMonthlyInstallments,
                    MonthlyInCurrentBusiness = user.YearsInCurrentJob,
                    TypeWorkSector = user.WorkSector
                };
                var criteria = GetCriteriaForProduct(targetProduct);
                var result = _actionPlanService.GenerateRoadmap(currentProfile , criteria);

                return Ok(new
                {
                    ClientName = user.FullName,
                    Roadmap = result
                });

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error generating roadmap for user");
                return StatusCode(500, "خطأ في معالجة طلبك.");
            }
        }




    }
}
