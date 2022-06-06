using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Models
{
    public class JsonModel
    {
        public Meta META { get; set; } 
        public Data data { get; set; }
        
    }
}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class CAD
{
    public string code { get; set; }
    public double value { get; set; }
}

public class Data
{

    public CAD CAD { get; set; }
    public EUR EUR { get; set; }
    public USD USD { get; set; }
    public PKR PKR { get; set; }
}

public class EUR
{
    public string code { get; set; }
    public double value { get; set; }
}

public class Meta
{
    public DateTime last_updated_at { get; set; }
}

public class Root
{
    public Meta meta { get; set; }
    public Data data { get; set; }
}

public class USD
{
    public string code { get; set; }
    public int value { get; set; }
}

public class PKR
{
    public string code { get; set; }
    public double value { get; set; }
}