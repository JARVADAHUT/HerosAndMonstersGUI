using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Inventory
    {
        public GearInventory GearContained { private set; get; }
        public ConsumablesInventory ConsumablesContained { private set; get; }

        public Inventory()
        {
            GearContained = new GearInventory();
            ConsumablesContained = new ConsumablesInventory();
        }


    }
}
