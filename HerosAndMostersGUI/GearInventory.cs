using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class GearInventory
    {
        private List<Gear> _inventoryContents;
        

        public GearInventory()
        {
            _inventoryContents = new List<Gear>();
        }

        public void Add(Gear g)
        {
            _inventoryContents.Add(g);
        }

        public void Add(List<Gear> theG)
        {
            foreach(Gear g in theG)
                _inventoryContents.Add(g);
        }

        public List<Gear> GetContents()
        {
            return _inventoryContents;
        }

    }
}
