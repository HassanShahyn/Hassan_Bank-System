using HassanBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.Interfaces
{
    public interface IBuyoutService
    {
        bool IsEligibleForBuyout(ClientProduct product);

        decimal CalculateNewInstallment(decimal amount, int Months ,decimal interestRate , ClientSegment segment);
    }

}
