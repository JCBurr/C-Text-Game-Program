using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class Location
    {
        // Basic attributes
        private string description;
        private string lookAroundDescription;
        private string name;
        protected int input;

        // Array/list type attributes
        public Dictionary<string, Action> possibleActions;
        public static Dictionary<string, Location> roomsList = new Dictionary<string, Location>();
        protected List<string> nearbyRooms;


        // Generic actions to be performed for every location on creation
        public Location()
        {
            this.possibleActions = new Dictionary<string, Action>();
            this.possibleActions.Add("Check inventory", Game.playerCharacter.UseInventory);
            this.possibleActions.Add("Look around", this.LookAround);
            this.possibleActions.Add("Move to another room", this.MoveToDifferentRoom);
        }


        // Handles displaying a menu and most user choice inputs
        public void DisplayMenu()
        {
            // Reset control variables in each room and space text input appropriately
            int i = 1;
            Console.WriteLine(" ");

            // Write out reference text for all available actions in this location's action list
            foreach(KeyValuePair<string, Action> possibleAction in this.possibleActions)
            {
                Console.WriteLine(i + ". - " + possibleAction.Key);
                i++;
            }

            // Display curent room and inventory information below the primary text
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Current Room: " + this.GetName());
            Game.playerCharacter.DisplayInventory();


            input = Game.GetUserInput(0, possibleActions.Count());

            Console.Clear();

            // Execute the action function corresponding to players' choice
            // Position in list is players' chosen number -1 since element 0 is not given as an option to the player
            possibleActions[possibleActions.Keys.ElementAt(input - 1)]();
        }


        // Base function to output description for each location generically
        protected virtual void LookAround()
        {
            Console.WriteLine(this.GetLookAroundDescription());
        }


        // Base function to handle movement choices generically. Can be overriden if additional
        // functionality is required when moving out of a specific room
        protected void MoveToDifferentRoom()
        {
            // Get generic movement options from this locations NearbyRooms list and display them
            Console.WriteLine("Which room would you like to go to?");
            int i = 1;
            List<string> nearbyRooms = this.GetNearbyRooms();

            foreach (string room in nearbyRooms)
            {
                Console.WriteLine(i + ". - " + room);
                i++;
            }

            // Always last element; choice to remain in current location
            Console.WriteLine(i + ". - " + "Stay in " + this.name);

            // Loop until user inputs acceptable value
            input = Game.GetUserInput(0, nearbyRooms.Count + 1);

            // If remaining in current location, display appropriate message but do not change location
            if (input == nearbyRooms.Count + 1)
            {
                Console.Clear();
                Console.WriteLine("You are still in the " + this.name.ToLower() + ".");
            }

            // Change the static currentLocation variable in the main game loop to the
            // element corresponding to users choice in static list of all rooms, using
            // nearbyRooms list in current location to get the correct key
            else
            {
                Game.currentLocation = Game.roomsList[nearbyRooms[input - 1]];

                Console.Clear();
                Game.currentLocation.OnEnterRoom();
            }
        }

        // Getters and setters
        public string GetName()
        {
            return this.name;
        }


        protected void SetName(string name)
        {
            this.name = name;
        }


        public string GetDescription()
        {
            return this.description;
        }


        protected void SetDescription(string description)
        {
            this.description = description;
        }


        public string GetLookAroundDescription()
        {
            return this.lookAroundDescription;
        }


        protected void SetLookAroundDescription(string lookAroundDescription)
        {
            this.lookAroundDescription = lookAroundDescription;
        }


        public List<string> GetNearbyRooms()
        {
            return this.nearbyRooms;
        }


        // Responsibility for adding nearby rooms is entirely placed on the child Location by making this virtual
        // and leaving the base call blank. This way, all rooms will have a unique set of nearby rooms but the
        // call to make the list is generic. Allows unlimited rooms to be added and makes creating new rooms easier
        protected virtual void PopulateNearbyRooms()
        { 
        }


        // Display basic description whenever a new location is entered. Can be overridden to add specific functionality
        // for certain rooms if desired.
        public virtual void OnEnterRoom()
        {
            Console.WriteLine(this.GetDescription());
        }
    }
}
