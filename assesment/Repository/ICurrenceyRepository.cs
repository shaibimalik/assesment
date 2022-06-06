using assesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Repository
{
   public interface ICurrenceyRepository
    {
        RepoResponse CurrencyUpdateValue();

        RepoResponse CurrencyGetValue();

        
    }
}
