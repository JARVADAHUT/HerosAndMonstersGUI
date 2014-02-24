using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class EquippedGearInventory
    {
        public Dictionary<EnumGearType, Gear> EquippedGear { private set; get; }

        public EquippedGearInventory()
        {
            EquippedGear = new Dictionary<EnumGearType, Gear>(6);

            EquippedGear.Add(EnumGearType.Head, new Gear(new GearAugments(), EnumGearType.Head));
            EquippedGear.Add(EnumGearType.Shoulders, new Gear(new GearAugments(), EnumGearType.Shoulders));
            EquippedGear.Add(EnumGearType.Armor, new Gear(new GearAugments(), EnumGearType.Armor));
            EquippedGear.Add(EnumGearType.Chest, new Gear(new GearAugments(), EnumGearType.Chest));
            EquippedGear.Add(EnumGearType.Legs, new Gear(new GearAugments(), EnumGearType.Legs));
            EquippedGear.Add(EnumGearType.Feet, new Gear(new GearAugments(), EnumGearType.Feet));
        }

        

    }
}
