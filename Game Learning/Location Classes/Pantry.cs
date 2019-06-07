using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class Pantry : Location
    {
        public Pantry()
        {
            this.SetDescription("Some rusted cans of food with decayed labels stand on \nold steel shelves, though they are mostly bare.");
            this.SetLookAroundDescription("Most of the cans are still sealed and probably remain edible.\nYou hear skittering that probably means rats or mice have moved in.\nOn the far wall, a door leads to what is most likely a cellar.");
            this.SetName("Pantry");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You walk into the pantry.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Cellar");
            this.nearbyRooms.Add("Kitchen");
            this.nearbyRooms.Add("Hallway");
        }

    }
}
