using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Gear
    {
        private GearAugments _myAugments;
        public EnumGearType GearType { private set; get; }
        private int _key;

        public Gear(GearAugments ga, EnumGearType gt)
        {
            GearType = gt;
            _myAugments = ga;

            _key = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            Thread.Sleep(1);
        }

        public GearAugments GetAugments()
        {
            return _myAugments;
        }
    }
}
