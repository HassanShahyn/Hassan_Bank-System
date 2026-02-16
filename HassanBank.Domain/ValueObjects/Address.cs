using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.ValueObjects
{
    public class Address
    {
        public string Street {  get; set; }
        public string City { get; set; }
        public string Governorate {  get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        public override string ToString()
        {
            return $"{Street}" +
                $"{City}" +
                $"{Governorate}" +
                $"{Country}" +
                $"{Zipcode}";
        }
    }
}
