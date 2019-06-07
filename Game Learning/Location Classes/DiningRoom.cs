using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class DiningRoom : Location
    {

        bool crowbarHere = true;
        public DiningRoom()
        {
            this.SetDescription("A layer of dust hangs in the air, lit by a beam of light pouring in from a\nhole in the far wall.");
            this.SetLookAroundDescription("One window is broken, but the others are\ncaked over with grime and blocked by ivy, leaving the room dark.\nA large wooden dining table sits in the center of the room, surrounded by aged\nchairs.");
            this.SetName("Dining Room");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You walk into the dining room.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Living Room");
            this.nearbyRooms.Add("Hallway");
            this.nearbyRooms.Add("Kitchen");
        }

        protected override void LookAround()
        {
            base.LookAround();
            if(crowbarHere)
            {
                Console.WriteLine("You see a crowbar lying against a far wall. Take it?");
                Console.WriteLine("1. - Take the crowbar");
                Console.WriteLine("2. - Leave the crowbar where it is");

                input = Game.GetUserInput(1, 2);

                if (input == 1)
                {
                    Crowbar crowbar = new Crowbar();
                    Game.playerCharacter.Inventory.Add(crowbar);
                    crowbarHere = false;
                    Console.Clear();
                    Console.WriteLine("You pick up the crowbar.");
                }
                else if(input == 2)
                {
                    Console.Clear();
                    Console.WriteLine("You decide to leave the crowbar for now.");
                }
            }
        }
    }
}
