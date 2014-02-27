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

        public Equipable(int key) : base(key)
        {

        }

        public void Use()
        {
            // swap
        }

        public String GetDescription()
        {
            return this.Description;
        }

        public InventoryItemType GetType()
        {
            return InventoryItemType.Equipable;
        }

    }
}
