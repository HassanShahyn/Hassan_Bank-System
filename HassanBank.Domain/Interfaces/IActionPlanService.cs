using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HassanBank.Domain.DTOs;

namespace HassanBank.Domain.Interfaces
{
    public interface IActionPlanService
    {
        ActionPlanResult GenerateRoadmap(ClientProfileDto profile, ProductEligibilityCriteria criteria);

    }
}
