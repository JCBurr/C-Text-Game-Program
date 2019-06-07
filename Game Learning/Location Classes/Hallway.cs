using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class Hallway : Location
    {

        protected string floorboardDescription = "\nOne of the floorboards is damaged, as if it had been partially pulled up.";
        protected string pictureFramesDescription = "You see some smashed wooden picture frames on the floor.";
        protected string cabinetDescription = "\nA lonely cabinet is nestled in corner next to the front door.";


        public Hallway()
        {
            this.SetDescription("A few of the grey iron light fixtures have fallen from the walls in the hall.\nLighter patches on the wallpaper show where pictures used to hang.");
            this.SetLookAroundDescription(pictureFramesDescription + floorboardDescription + cabinetDescription);
            this.SetName("Hallway");
            this.nearbyRooms = new List<string>();
            this.PopulateNearbyRooms();
        }


        public override void OnEnterRoom()
        {
            Console.WriteLine("You walk into the hall connecting the downstairs rooms.");
            base.OnEnterRoom();
        }


        protected override void PopulateNearbyRooms()
        {
            this.nearbyRooms.Add("Living Room");
            this.nearbyRooms.Add("Dining Room");
            this.nearbyRooms.Add("Kitchen");
            this.nearbyRooms.Add("Pantry");
        }


        protected override void LookAround()
        {
            if (Game.playerCharacter.Inventory.OfType<Crowbar>().Any() && !this.possibleActions.ContainsKey("Use the crowbar to lift the damaged floorboard"))
            {
                this.possibleActions.Add("Use the crowbar to lift the damaged floorboard", this.RipUpFloorboardWithCrowbar);
            }
            base.LookAround();
        }


        public void RipUpFloorboardWithCrowbar()
        {
            Console.WriteLine("You use the crowbard to pry up the damaged floorboard. Underneath,\nyou find a small hollowed out nook with a rusted metal box inside. The box is locked.\nYou take the box.");

            this.floorboardDescription = "\nThe now broken floorboard lies next to the hollowed nook in the floor where you found the \nmetal box.";
            this.SetLookAroundDescription(pictureFramesDescription + floorboardDescription + cabinetDescription);
            this.possibleActions.Remove("Use the crowbar to lift the damaged floorboard");
        }
    }
}
