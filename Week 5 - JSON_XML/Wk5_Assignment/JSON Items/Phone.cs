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
    public class Phone
    {
        [JsonProperty("type")]
        string type { get; set; }

        [JsonProperty("number")]
        string number { get; set; }

        [JsonProperty("CanContact")]
        bool CanContact { get; set; }
    }
}
