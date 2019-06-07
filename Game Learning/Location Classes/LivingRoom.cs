using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class LivingRoom : Location
    {

        public LivingRoom()
        {
            this.SetDescription("The dusty room contains little more than basic furnishings at first glance.");
            this.SetLookAroundDescription("You see a broken TV, a dilapidated sofa and an old vase with an\nunusually narrow neck.");
            this.SetName("Living Room");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You walk into the living room.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Dining Room");
            this.nearbyRooms.Add("Hallway");
        }


        //private void Dance()
        //{
        //    Console.WriteLine("You breakdance for a solid 32 minutes, completely alone, in the\ndusty living room. If you had asthma, you'd be dead right now.");
        //    this.possibleActions.Remove("Dance like a maniac");
        //}

    }
}
