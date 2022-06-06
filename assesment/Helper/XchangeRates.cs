using assesment.Models;
using assesment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Helper
{
    public class XchangeRates
    {
 
        public static void ConvertRates(CurrencyModel currencyModel,JsonModel jsonModel) {

            double ConvAmountUSD = currencyModel.Amount * jsonModel.data.USD.value;
            double AmountUserCurrency = currencyModel.Amount * jsonModel.data.CAD.value;

            currencyModel.AmountUSD = ConvAmountUSD;
            currencyModel.AmountUserCurrency = AmountUserCurrency;
           
        }
    }
}
