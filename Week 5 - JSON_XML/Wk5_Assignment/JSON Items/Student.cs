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
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("isEnrolled")]
        public bool isEnrolled { get; set; }

        [JsonProperty("YearsEnrolled")]
        public int YearsEnrolled { get; set; }
        
        [JsonProperty("address1")]
        public Address Address1 { get; set; }
        
        [JsonProperty("address2")]
        public Address Address2 { get; set; }
        
        [JsonProperty("phoneNumbers")]
        public List<Phone> PhoneNumbers = new List<Phone>();
    }
}
