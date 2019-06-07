using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class Item
    {
        protected string description;
        protected bool usable;
        protected bool isConsumable;
        public string name;


        public virtual void UseItem()
        {
            if (this.usable != true)
            {
                Console.WriteLine("You can't use this.");
            }
        }


        public string GetDescription()
        {
            return this.description;
        }

    }
}
