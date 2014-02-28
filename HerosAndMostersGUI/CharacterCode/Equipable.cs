using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.CharacterCode
{
    class Equipable : InventoryItem
    {

        public Equipable(int key)
            : base(key)
        {

        }

        public override void Use()
        {
            // swap
        }

        public override String GetDescription()
        {
            return this.Description;
        }

        public override InventoryItemType GetType()
        {
            return InventoryItemType.Equipable;
        }

    }
}