using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Models
{
    public class CurrencyModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyName { get; set; }
        public double AmountUSD { get; set; }
        public double AmountUserCurrency { get; set; }

        

    }
}
