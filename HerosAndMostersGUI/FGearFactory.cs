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
            
            test.Agility = rnd.Next();
            test.Health = rnd.Next();
            test.Defence = rnd.Next();
            test.Resource = rnd.Next();
            test.Intelligence = rnd.Next();
            test.Strength = rnd.Next();

            return new Gear(test, EnumGearType.Chest);

        }

    }
}
