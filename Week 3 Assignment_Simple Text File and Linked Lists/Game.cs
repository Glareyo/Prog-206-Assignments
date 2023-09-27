using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Week_3_Assignment_Simple_Text_File_and_Linked_Lists.LinkedList_Classes;
using static Week_3_Assignment_Simple_Text_File_and_Linked_Lists.UIUtility;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    internal class Game
    {
        Player player;
        DataHandler data;
        DoublyLinkedList resultsData;

        public void InitGame()
        {
            data = new DataHandler();
            resultsData = new DoublyLinkedList("Results");
            data.InitDataCreation();

            Prompt("Hello!");
            
            string name = PromptAndAnswer("Please Enter your name: ");

            player = new Player(name, data.AllRooms[1]);
            Console.Clear();
            string[] introM =
            {
                $"Welcome ",
                player.Name,
                " to the ",
                "Dangerous Dungeon of the ",
                "WIZARD!"
            };
            ConsoleColor[] introC =
            {
                ConsoleColor.White,
                ConsoleColor.Cyan,
                ConsoleColor.White,
                ConsoleColor.Yellow,
                ConsoleColor.Red
            };
            Print(introM, introC, true, false);

            Continue();
            Console.Clear();

            while (!EndGame())
                PlayGame();

            if (player.hp <= 0)
            {
                string[] endM = { "You have been ", "SLAYED","!"};
                ConsoleColor[] endC = { ConsoleColor.White, ConsoleColor.Red,ConsoleColor.White};
                Print(endM, endC, true, false);

                resultsData.AddNode("Game Lost", "Player has LOST the Game");
            }
            else
            {
                string[] endM = { "All ", "Monsters ", "have been ", "Slayed", "!" };
                ConsoleColor[] endC = { ConsoleColor.White, ConsoleColor.Magenta, ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                Print(endM, endC, true, false);

                resultsData.AddNode("Game Won", "Player has WON the Game");
            }

            resultsData.PrintResults();

            Continue();
        }


        void PlayGame()
        {
            DisplayUI();
            string input = Convert.ToString(Console.ReadKey().KeyChar).ToLower();
            PlayerInput(Convert.ToChar(input));
        }

        bool EndGame()
        {
            bool MonstersAllSlayed = true;
            foreach (Room r in data.AllRooms)
                if (r.Monster != null) MonstersAllSlayed = false;

            if (player.hp <= 0) return true;
            else return MonstersAllSlayed;
        }

        void DisplayUI()
        {
            //Display Current Room name
            Print(player.Location.GetName, ConsoleColor.Green, true, false);

            //Display current room description
            Print(player.Location.GetDescription, ConsoleColor.Yellow, true, false);

            Console.WriteLine();
            //Gather full messege about adjacent rooms
            for (int index = 0; index < 4; index++)
            {
                Room room = data.FindRoom(player.Location.AdjacentRoomsIDs[index], data.AllRooms);

                ConsoleColor pathColor = ConsoleColor.Red;
                if (room.GetID == 0) pathColor = ConsoleColor.Red;
                else pathColor = ConsoleColor.Green;

                string[] messeges =
                {
                    "The ",
                    room.GetName,
                    " is to the ",
                    //https://stackoverflow.com/questions/41666625/c-sharp-can-you-call-an-enum-by-the-number-value
                    //Showed how to call enums based on an integer instead.
                    ((Directions)index).ToString() 
                };
                ConsoleColor[] colors =
                {
                    ConsoleColor.White,
                    pathColor,
                    ConsoleColor.White,
                    pathColor
                };

                Print(messeges, colors, true, false);
            }
            
            Console.WriteLine();
            //Display Items
            for (int index = 0; index < player.Location.loot.Count; index++)
            {
                Item item = player.Location.loot[index];

                string[] messeges =
                {
                    "There is a/an ",
                    item.Name,
                    " here"
                };
                ConsoleColor[] colors =
                {
                    ConsoleColor.White,
                    ConsoleColor.Cyan,
                    ConsoleColor.White
                };

                Print(messeges, colors, true, false);
            }
            Console.WriteLine();
            //Display Monster if applicable
            if (player.Location.Monster !=null)
            {
                string[] print = { "There is a ", player.Location.Monster.Name, " lurking here..." };
                ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Magenta, ConsoleColor.White };
                Print(print, colors, true, false);
            }
            Console.WriteLine();

            //Display Controls
            string[] inputOpt =
            {
                "N", " = Go North; ","S", " = Go South; ",
                "E", " = Go East; ","W", " = Go West; ",
                "P", " = Pickup Item; ", "F"," = Fight Monster; "
            };
            ConsoleColor[] colorsOpts = {
                ConsoleColor.Red,ConsoleColor.White, ConsoleColor.Red, ConsoleColor.White,
                ConsoleColor.Red,ConsoleColor.White,ConsoleColor.Red,ConsoleColor.White,
                ConsoleColor.Cyan,ConsoleColor.White,ConsoleColor.Cyan,ConsoleColor.White
            };
            Print(inputOpt, colorsOpts, true, false);
        }

        void PlayerInput(char input)
        {
            char[] moveInputs = { 'n', 's', 'e', 'w' };

            Console.Clear();

            //Check to see if it is a move input
            if (moveInputs.Contains(input))
                PlayerMoves(input);
            else if (input == 'p')
            {
                bool runningMenu = true;
                while (runningMenu)
                    runningMenu = !PlayerPicksUp();
            }
            else if (input == 'f')
            {
                if (player.Location.Monster == null) UnaccessiblePrompt("There is no monster here...");
                else
                {
                    Monster monster = player.Location.Monster;
                    bool runningMenu = true;
                    while (runningMenu)
                        runningMenu = !PlayerFights(monster);

                    if (player.Location.Monster != monster)
                        RecordResults(monster, player.Location, true);
                    else
                        RecordResults(monster, player.Location, false);


                }
            }
        }

        void PlayerMoves(char input)
        {
            char[] moveInputs = { 'n', 's', 'e', 'w' };

            //Find the index of the target direction
            int location = 0;
            for (int index = 0; index < moveInputs.Length; index++)
                if (moveInputs[index] == input) location = index;

            //Set the room
            //https://stackoverflow.com/questions/41666625/c-sharp-can-you-call-an-enum-by-the-number-value
            //Showed how to call enums based on an integer instead.
            Room targetRoom = data.FindRoom(player.Location.GiveAdjRoomID((Directions)location), data.AllRooms);
            if (targetRoom.GetID == 0) Print("Unable to Go There", ConsoleColor.Red, true, false);
            else
            {
                player.Move(targetRoom);

                //https://stackoverflow.com/questions/41666625/c-sharp-can-you-call-an-enum-by-the-number-value
                //Showed how to call enums based on an integer instead.
                string[] messeges = { "You go ", $"{(Directions)location}" };


                ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Cyan };

                Print(messeges, colors, true, false);
                Console.WriteLine("\n");
            }
        }

        bool PlayerPicksUp()
        {
            Print_Underline("Picking Up", ConsoleColor.Cyan, true);
            //Display Prompt
            Print("What do you want to pick up?", ConsoleColor.Red, true, false);

            //Cancel Option
            string[] cancelM = { $"0. ", $"Cancel" };
            ConsoleColor[] cancelC = { ConsoleColor.Yellow, ConsoleColor.Red };
            Print(cancelM, cancelC, true, false);

            //List all possible items
            for (int index = 1; index <= player.Location.loot.Count; index++)
            {
                string[] messeges = { $"{index}. ", $"{player.Location.loot[index-1].Name}" };
                ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Cyan };
                Print(messeges, colors, true, false);
            }

            //Get players input
            try
            {
                Console.WriteLine();
                string input = PromptAndAnswer("Input the Corresponding Number: ");
                Console.Clear();

                int selectedInput = Convert.ToInt32(input);

                //Cancel
                if (selectedInput == 0) return true;
                else
                {
                    Item item = player.Location.loot[selectedInput - 1];
                    player.Inventory.Add(item);
                    player.Location.loot.Remove(item);

                    string[] m = { "You Picked up a/an ", item.Name };
                    ConsoleColor[] c = { ConsoleColor.White, ConsoleColor.Cyan };
                    Print(m, c, true, false);
                }
            }
            catch
            {//Catches invalid int converts or out of range inputs
                Print("Invalid Input", ConsoleColor.Red, true, false);
            }

            return false;
        }

        bool PlayerFights(Monster monster)
        {
            Console.WriteLine();
            Print_Underline("Fighting:", ConsoleColor.Red, true);
            Console.WriteLine();
            Print_Underline(monster.Name, ConsoleColor.Magenta, true);
            string[] monsterStats = { "Health: ", monster.HP.ToString() };
            ConsoleColor[] color = { ConsoleColor.Green, ConsoleColor.Red };
            Print(monsterStats, color, true, false);

            string[] yourStatsM = { "Your Health: ", player.hp.ToString() };
            ConsoleColor[] yourStatsC = { ConsoleColor.White, ConsoleColor.Green };
            Print(yourStatsM, yourStatsC, true, false);

            Console.WriteLine("\n");
            //Display Prompt
            Print("Select a Weapon to Use: ", ConsoleColor.Red, true, false);

            //Display all possible weapons in inventory
            //Cancel Option
            string[] cancelM = { $"0. ", $"Retreat" };
            ConsoleColor[] cancelC = { ConsoleColor.Yellow, ConsoleColor.Red };
            Print(cancelM, cancelC, true, false);

            //List all possible items
            for (int index = 1; index <= player.Inventory.Count; index++)
            {
                string[] messeges = { $"{index}. ", $"{player.Inventory[index - 1].Name}", "; DMG = ", player.Inventory[index - 1].Damage.ToString(), ";",
                " Duration = ",player.Inventory[index-1].duration.ToString(),";" };
                ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Cyan,ConsoleColor.White,ConsoleColor.Red,ConsoleColor.White, 
                ConsoleColor.White, ConsoleColor.Yellow,ConsoleColor.White};
                Print(messeges, colors, true, false);
            }

            //Get valid player input
            try
            {
                Console.WriteLine();
                string input = PromptAndAnswer("Input the Corresponding Number: ");
                Console.Clear();
                int selectedInput = Convert.ToInt32(input);
                //Cancel
                if (selectedInput == 0)
                {
                    string[] monsterM = { "The ", monster.Name," attacks!"};
                    ConsoleColor[] monsterC = { ConsoleColor.White, ConsoleColor.Magenta, ConsoleColor.Red };
                    Print(monsterM, monsterC, true, false);

                    string[] dmgM = { "You take ", monster.AP.ToString(), " Points of ", " Damage", "!" };
                    ConsoleColor[] dmgC = { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.White };
                    Print(dmgM, dmgC, true, false);

                    player.hp -= monster.AP;

                    return true;
                }
                else
                {
                    Item item = player.Inventory[selectedInput - 1];
                    //Decrease monster health
                    monster.HP -= item.Damage;
                    item.duration -= 1;
                    //Remove Item if duration = 0;
                    if (item.duration <= 0) player.Inventory.Remove(item);

                    string[] m = { "You strike with the ", item.Name };
                    ConsoleColor[] c = { ConsoleColor.White, ConsoleColor.Cyan };
                    string[] m2 = { "Damage Dealt: ", item.Damage.ToString() };
                    ConsoleColor[] c2 = { ConsoleColor.White, ConsoleColor.Red };

                    Print(m, c, true, false);
                    Print(m2, c2, true, false);

                    if (monster.HP <= 0)
                    {
                        string[] m3 = { "The ", monster.Name, " has been ", "Slayed!" };
                        ConsoleColor[] c3 = { ConsoleColor.White, ConsoleColor.Magenta, ConsoleColor.White, ConsoleColor.Red };

                        Print(m3, c3, true, false);
                        player.Location.Monster = null;
                        Continue();
                        return true;
                    }
                }
            }
            catch
            {//Catches invalid int converts or out of range inputs
                Print("Invalid Input", ConsoleColor.Red, true, false);
            }

            return false;
        }


        void RecordResults(Monster monster, Room Location, bool battleWon)
        {
            string result = "";
            result += $"{monster.Name} fought in the {Location.GetName}.\n";

            if (battleWon)
                result += $"Battle Won";
            else
                result += $"Battle Lost";

            int count = resultsData.Nodes.Count;
            resultsData.AddNode($"Battle {count+1}", result);
        }
    }
}
