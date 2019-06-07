using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class Kitchen : Location
    {
        public Kitchen()
        {
            this.SetDescription("A variety of rusted cooking equipment still hangs from hooks on the walls.");
            this.SetLookAroundDescription("Most of the pots and pan look high quality; with a thorough clean, they\nmay still be usable. Doors hang off some of the cabinets and\ncupboard where the wood has rotted or the hinges rusted.");
            this.SetName("Kitchen");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You walk into the kitchen.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Dining Room");
            this.nearbyRooms.Add("Hallway");
            this.nearbyRooms.Add("Pantry");
        }

    }
}
