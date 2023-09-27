using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Week_3_Assignment_Simple_Text_File_and_Linked_Lists.UIUtility;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    internal class Game
    {
        Player player;
        DataHandler data;


        public void InitGame()
        {
            data = new DataHandler();
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
        }


        void PlayGame()
        {

            DisplayUI();


            PlayerInput(Console.ReadKey().KeyChar);

        }

        bool EndGame()
        {
            return false;
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

                string[] messeges =
                {
                    "The ",
                    room.GetName,
                    " is to the ",
                    ((Directions)index).ToString()
                };
                ConsoleColor[] colors =
                {
                    ConsoleColor.White,
                    ConsoleColor.Green,
                    ConsoleColor.White,
                    ConsoleColor.Red
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
                Print("Picking Up", ConsoleColor.Cyan, true, false);
                //Display Prompt
                Print("What do you want to pick up?", ConsoleColor.Red, true, false);

                //Cancel Option
                string[] cancelM = { $"0. ", $"Cancel" };
                ConsoleColor[] cancelC = { ConsoleColor.Yellow, ConsoleColor.red };
                Print(cancelM, cancelC, true, false);

                //List all possible items
                for (int index = 1; index < player.Location.loot.Count; index++) 
                {
                    string[] messeges = { $"{index}. ", $"{player.Location.loot[index]}" };
                    ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Cyan };
                    Print(messeges, colors, true, false);
                }

                //Get players input
                try
                {
                    int selectedInput = Convert.ToInt32(Console.ReadKey().KeyChar);
                    if (selectedInput !=0)
                    {
                       // player.Inventory.Add()
                    }
                }
                catch
                {
                    Print("Invalid Input", ConsoleColor.Red, true, false);
                }

                //Add item to player inventory
                //Remove Item from room
                //Refresh display
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
            Room targetRoom = data.FindRoom(player.Location.GiveAdjRoomID((Directions)location), data.AllRooms);
            if (targetRoom.GetID == 0) Print("Unable to Go There", ConsoleColor.Red, true, false);
            else
            {
                player.Move(targetRoom);
                string[] messeges = { "You go ", $"{(Directions)location}" };


                ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Cyan };

                Print(messeges, colors, true, false);
                Console.WriteLine("\n");
            }
        }
    }
}
