using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static FruitEditor.UIUtility;

namespace FruitEditor
{
    public class Editor
    {
        private string url;
        private static readonly HttpClient client = new HttpClient();

        public Editor(string _url)
        {
            this.url = _url;
        }
        public async Task RunAddFruitTest(string fruit)
        {
            var values = new Dictionary<string, string>
            {
                 { "add-fruit", fruit }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        public async Task RunRemoveFruitTest(string fruit)
        {
            var values = new Dictionary<string, string>
            {
                 { "remove-fruit", fruit }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        public async Task GetFruitTest()
        {
            var response = await client.GetAsync(url);

            var responseString = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseString);

            PrintData(responseString);
        }

        public void Start()
        {
            string prompt = "Select an Option";
            string[] options =
            {
                "Add",
                "Remove",
                "Show",
                "Exit"
            };


            bool running = true;
            while (running)
            {
                int num = MenuPrompt(prompt, options);
                switch(num)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        Show();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        void Add()
        {
            Prompt("Type a Fruit to ADD");
            string answer = GetInput();

            RunAddFruitTest(answer);
            //Add Fruit to Database
        }
        void Remove()
        {
            Prompt("Type a Fruit to REMOVE");
            string answer = GetInput();

            RunRemoveFruitTest(answer);
        }
        void Show()
        {
            GetFruitTest();
            Continue();
        }

        void PrintData(string responseString)
        {
            string unwantedChars = "[]:{},";
            List<string> data = new List<string>();

            //Get the data in a list
            foreach (string s in responseString.Split("\""))
            {
                bool containsUnwantedChars = false;
                foreach (char c in unwantedChars)
                {
                    if (s.Contains(c))
                    {
                        containsUnwantedChars = true;
                    }
                }
                if (!containsUnwantedChars)
                {
                    data.Add(s);
                }
            }

            data.RemoveAt(0);

            for(int i = 0; i < data.Count; i++)
            {
                CenterString($"{i+1}. {data[i]}", ConsoleColor.Yellow);
            }
        }
    }
}
