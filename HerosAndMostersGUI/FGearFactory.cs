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
            GearAugments test = new GearAugments();
            Random rnd = new Random();
            
            test.Agility = rnd.Next(100);
            test.Health = rnd.Next(100);
            test.Defence = rnd.Next(100);
            test.Resource = rnd.Next(100);
            test.Intelligence = rnd.Next(100);
            test.Strength = rnd.Next(100);

            return new Gear(test, EnumGearType.Chest);

        }

    }
}
