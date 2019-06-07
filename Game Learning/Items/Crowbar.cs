using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class Crowbar : Item
    {

        public Crowbar()
        {
            this.name = "Crowbar";
            this.usable = true;
            this.isConsumable = false;
            this.description = "A rusted but sturdy iron crowbar; might be useful";
        }


        public override void UseItem()
        {
            base.UseItem();
        }

    }
}
