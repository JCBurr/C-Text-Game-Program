using System;
using System.Collections.Generic;


namespace Adventure
{
    public static class Game 
    {

        public static Location currentLocation;
        public static Boolean gameEnded = false;
        public static Dictionary<string, Location> roomsList;
        public static Player playerCharacter;


        public static void StartGame()
        {

            Console.WriteLine("Welcome to the game.");
            Console.WriteLine("This is just practice.");

            playerCharacter = new Player();
            playerCharacter.Dialog("Hello world, my name is " + playerCharacter.GetCharacterName() + ", I talk in the color " + playerCharacter.GetDialogColor() + ".");

            InitialiseRooms();
        }


        public static void GameLoop()
        {
            while (gameEnded != true)
            {
                currentLocation.DisplayMenu();
            }
        }


        private static void InitialiseRooms()
        {
            roomsList = new Dictionary<string, Location>();
            
            LivingRoom livingRoom = new LivingRoom();
            roomsList.Add("Living Room", livingRoom);

            DiningRoom diningRoom = new DiningRoom();
            roomsList.Add("Dining Room", diningRoom);

            Hallway hallway = new Hallway();
            roomsList.Add("Hallway", hallway);

            Pantry pantry = new Pantry();
            roomsList.Add("Pantry", pantry);

            Kitchen kitchen = new Kitchen();
            roomsList.Add("Kitchen", kitchen);

            Cellar cellar = new Cellar();
            roomsList.Add("Cellar", cellar);

            currentLocation = livingRoom;
            currentLocation.OnEnterRoom();
            
        }


        public static int GetUserInput(int minRange, int maxRange)
        {
            bool inputAccepted = false;
            int input = 0;

            // Loop until user inputs acceptable value
            while (inputAccepted == false)
            {
                input = Convert.ToInt32(Console.ReadLine());

                if (input >= minRange && input <= maxRange)
                {
                    inputAccepted = true;
                }
                else
                {
                    Console.WriteLine("Please enter a number representing one of the listed options.");
                }
            }

            return input;
        }

    }


    class Program
    {
        static void Main()
        {
            Game.StartGame();
            Game.GameLoop();
            Console.ReadKey();
        }
    }
}
