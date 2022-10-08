using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Var
    {
        public string var { get; set; }
    }
    public class And
    {
        public List<object> In { get; set; }

        [JsonProperty(">")]
        public List<object> greaterthan { get; set; }

        [JsonProperty("<")]
        public List<object> lessthan { get; set; }
    }


    public class Advanced
    {
        public List<And> and { get; set; }
    }

    public class Query
    {
        public Advanced advanced { get; set; }
    }

    public class LegalHold
    {
        public Query query { get; set; }
    }

    public class LegalHoldRequest
    {
        public string id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string title { get; set; }
        public LegalHold legal_hold { get; set; }
    }


}
