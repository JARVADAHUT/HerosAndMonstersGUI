using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class FGearFactory
    {
        public static Gear GetGear()
        {
            return new Gear(new GearAugments(), EnumGearType.Chest);
        }

    }
}
