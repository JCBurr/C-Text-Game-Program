using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class Cellar : Location
    {
        public Cellar()
        {
            this.SetDescription("The cellar smells musky and the dark stone walls give the room a\ngrim atmosphere.");
            this.SetLookAroundDescription("You hear dripping water from somewhere. The flagstones underfoot are damp, but mostly seem intact.\nThe cellar is ominously dark and you fear moving into the room proper\nwithout a light source.");
            this.SetName("Cellar");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You head down the steps into a dank cellar.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Pantry");
        }

    }
}
