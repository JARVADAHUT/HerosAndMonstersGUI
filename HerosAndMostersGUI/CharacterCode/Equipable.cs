using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.CharacterCode
{
    public class Equipable : GenericItems
    {
        public EnumGearSlot Slot { get; set; }

        public Equipable(int key, List<EffectInformation> properties, String description)
            : base(key)
        {
            this.Key = key;
            this.Properties = properties;
            this.Description = description;
        }

        public override bool Use()
        {
            return true;
            // swap
        }

        new public EnumItemType GetType()
        {
            return EnumItemType.Equipable;
        }



    }
}