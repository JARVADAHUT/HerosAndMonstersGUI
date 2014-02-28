using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    class Consumable : InventoryItem
    {

        public Consumable(int key)
            : base(key)
        {

        }

        public override void Use()
        {
            // use and destroy
        }

        public override String GetDescription()
        {
            return this.Description;
        }

        public override InventoryItemType GetType()
        {
            return InventoryItemType.Consumable;
        }

    }
}
