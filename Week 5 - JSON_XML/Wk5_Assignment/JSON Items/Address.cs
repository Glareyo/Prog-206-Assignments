using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_Assignment.JSON_Items
{
    // Credit:
    // Leo Hazou, for providing documentation and presentation of XML file reading,
    // Code below is an exact copy of the code provided in the presentations with a few minor changes.
    public class Address
    {
        [JsonProperty("streetAddress")]
        public string streetAddress { get; set; }
        
        [JsonProperty("city")]
        public string city { get; set; }
        
        [JsonProperty("state")]
        public string state { get; set; }
        
        [JsonProperty("postalCode")]
        public string postalCode { get; set; }

        public string[] RetrieveFullAddress()
        {
            string[] info =
            {
                streetAddress,
                city,
                state,
                postalCode
            };

            return info;
        }
    }
}
