using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    public class InventoryItem
    {
        public InventoryCategories Category { set; get; }
        public Dictionary<StatsType,int[]> _properties; 
        //Meditate on this
    }
}
