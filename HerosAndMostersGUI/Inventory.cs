using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Inventory
    {
        public InventoryContents<Gear> GearContained { private set; get; }
        public InventoryContents<IConsumable> ConsumablesContained { private set; get; }

        public Inventory()
        {
            GearContained = new InventoryContents<Gear>();
            ConsumablesContained = new InventoryContents<IConsumable>();
        }


    }
}
