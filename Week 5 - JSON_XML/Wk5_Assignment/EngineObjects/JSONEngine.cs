using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wk5_Assignment.CVS_Items;
using Wk5_Assignment.JSON_Items;

namespace Wk5_Assignment.EngineObjects
{
    public class JSONEngine : Engine
    {
        public override void BeginDeciphering(IFileInformation file)
        {
            base.BeginDeciphering(file);
        }
        public override string DecipherFile(IFileInformation file)
        {
            string dataString = "";

            // Credit:
            // Leo Hazou, for providing documentation and presentation of XML file reading,
            // Code below is an exact copy of the code provided in the presentations with a few minor changes.


            // Initiate reading of the file
            using (StreamReader sr = new StreamReader(file.Path))
            {
                // Deserialize the objects and place into student
                Student student = JsonConvert.DeserializeObject<Student>(sr.ReadToEnd());

                ///Code works
                /*Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                foreach(string s in student.Address1.RetrieveFullAddress())
                    Console.WriteLine(s);
                foreach(Phone phone in student.PhoneNumbers)
                {
                    Console.WriteLine(phone.number);
                    Console.WriteLine(phone.CanContact);
                    Console.WriteLine(phone.type);
                }*/


                //Get the student and add into the IFileInformation Data
                int lineNum = 1;
                // Store first and last name
                string data = $"Line#{lineNum} : Field#1={student.FirstName} ==> Field#2{student.LastName}\n\n";
                lineNum++;
                // Add IsEnrolled and YearsEnrolled
                data += $"Line#{lineNum} : Field#1={student.isEnrolled} ==> Field#2={student.YearsEnrolled}\n\n";
                lineNum++;

                // Add addresses
                data += AddAddress(lineNum, student.Address1);
                lineNum++;

                data += AddAddress(lineNum, student.Address2);
                lineNum++;

                //Add Phone Numbers
                

            }

            return dataString;
        }

        public string AddAddress(int lineNum, Address address)
        {
            string returningData = $"";

            // Check to see if the address exists, else return an empty string
            if (address != null)
            {
                returningData = $"Line#{lineNum} : ";
                returningData += $"Field#1={address.streetAddress} ==> ";
                returningData += $"Field#2={address.city} ==> ";
                returningData += $"Field#3={address.state} ==> ";
                returningData += $"Field#4={address.postalCode}\n\n";
            }

            return returningData;
        }
    }
}
