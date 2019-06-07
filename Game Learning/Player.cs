using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Adventure
{
    public class Player
    {
        // Basic attributes
        private string CharacterName;
        private string DialogColor;

        // Array/list type attributes
        public List<Item> Inventory;


        public Player()
        {
            NameCharacter();
            ChooseDialogColour();
            this.Inventory = new List<Item>();
        }


        public string GetCharacterName()
        {
            return CharacterName;
        }


        public string GetDialogColor()
        {
            return DialogColor;
        }


        private void NameCharacter()
        {
            Console.WriteLine("Enter your name.");

            CharacterName = Console.ReadLine();

            Console.WriteLine("You are " + CharacterName + ".");
        }


        private void ChooseDialogColour()
        {
            Console.WriteLine("Pick yourself a dialogue color, " + CharacterName + ".");
            Console.WriteLine("You can have red, cyan, yellow or magenta.");
            DialogColor = Console.ReadLine();
        }


        public void Dialog(string message)
        {
            if (DialogColor == "red" || DialogColor == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (DialogColor == "cyan" || DialogColor == "Cyan")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (DialogColor == "magenta" || DialogColor == "Magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (DialogColor == "yellow" || DialogColor == "Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }


        public void DisplayInventory()
        {
            Console.SetCursorPosition(0, 21);
            if (this.Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.Write("Your inventory contains the following items: ");
                foreach (Item inventoryItem in this.Inventory)
                {
                Console.Write(" " + inventoryItem.name + ",");
                }
                Console.Write("\b \n");
            }
        }


        public void UseInventory()
        {
            int i = 1;
            if (Game.playerCharacter.Inventory.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have nothing in your inventory.");
            }
            else
            {
                Console.WriteLine("1. Use an item");
                Console.WriteLine("2. Inspect an item");
                Console.WriteLine("3. Close inventory");

                int input = Game.GetUserInput(1, 3);

                if (input == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Use which item?");
                    foreach (Item inventoryItem in Game.playerCharacter.Inventory)
                    {
                        Console.WriteLine(i + ". - " + inventoryItem.name);
                        input = Game.GetUserInput(1, Game.playerCharacter.Inventory.Count);

                        Console.Clear();

                        Game.playerCharacter.Inventory[input - 1].UseItem();
                    }
                }

                else if (input == 2)
                {
                    Console.WriteLine("Inspect which item?");
                    foreach (Item inventoryItem in Game.playerCharacter.Inventory)
                    {
                        Console.WriteLine(i + ". - " + inventoryItem.name);
                        input = Game.GetUserInput(1, Game.playerCharacter.Inventory.Count);

                        Console.Clear();

                        Console.WriteLine(Game.playerCharacter.Inventory[input - 1].GetDescription());
                    }
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
