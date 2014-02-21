using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Gear : IEquatable<Gear>
    {
        private GearAugments _myAugments;
        public EnumGearType GearType { private set; get; }
        public int Key { private set; get; }
        public string Description { private set; get; }

        public Gear(GearAugments ga, EnumGearType gt)
        {
            GearType = gt;
            _myAugments = ga;
            Description = "gearrrr: " + _myAugments.Agility;

            Key = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            Thread.Sleep(1);
        }

        public GearAugments GetAugments()
        {
            return _myAugments;
        }

        public bool Equals(Gear other)
        {
            return this.Key == other.Key;
        }
    }
}
