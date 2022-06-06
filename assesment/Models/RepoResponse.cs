using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Models
{
    public class RepoResponse
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Flag { get; set; }
        public DataSet Data { get; set; }
    }
}
