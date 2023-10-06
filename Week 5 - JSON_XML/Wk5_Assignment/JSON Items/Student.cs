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
    public class Student
    {
        [JsonProperty("firstName")]
        string FirstName { get; set; }
        [JsonProperty("lastName")]
        string LastName { get; set; }
        [JsonProperty("isEnrolled")]
        bool isEnrolled { get; set; }
        [JsonProperty("YearsEnrolled")]
        int YearsEnrolled { get; set; }
        [JsonProperty("address1")]
        Address Address1 { get; set; }
        [JsonProperty("address2")]
        Address Address2 { get; set; }
        [JsonProperty("phoneNumbers")]
        List<Phone> PhoneNumbers = new List<Phone>();
    }
}
