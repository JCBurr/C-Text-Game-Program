using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class MetalBox : Item
    {
        public MetalBox()
        {
            this.name = "Metal Box";
            this.usable = true;
            this.isConsumable = true;
            this.description = "It looks like an old tin lunchbox, but it has a sturdy\nlock on the front.";
        }


        public override void UseItem()
        {
            base.UseItem();
        }
    }
}
