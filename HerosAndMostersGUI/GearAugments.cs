using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class GearAugments
    {
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Resource { get; set; }

        public GearAugments()
        {
            Intelligence = 0;
            Strength = 0;
            Agility = 0;
            Defence = 0;
            Health = 0;
            Resource = 0;
        }
    }
}
