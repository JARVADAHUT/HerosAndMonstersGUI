using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Consumable : GenericItems
    {

        public Consumable(int key, List<EffectInformation> properties, String description)
            : base(key)
        {
            this.Key = key;
            this.Properties = properties;
            this.Description = description;
        }

        public override bool Use()
        {
            return true;
            // use and destroy
        }

        new public EnumItemType GetType()
        {
            return EnumItemType.Consumable;
        }

    }
}
