using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.Enums
{
    public enum OpportunityStatus
    {
        Pending,
        Contacted,
        Converted,
        Expired,
        Escalated // لو الـ SLA باظ

    }

}
