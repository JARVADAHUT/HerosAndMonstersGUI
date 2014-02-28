using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    class Consumable : GenericItems
    {

        public Consumable(int key, List<EffectInformation> properties, String description)
            : base(key)
        {
            this.Key = key;
            this.Properties = properties;
            this.Description = description;
        }

        public void Use()
        {
            // use and destroy
        }

        public String GetDescription()
        {
            return this.Description;
        }

        new public InventoryItemType GetType()
        {
            return InventoryItemType.Consumable;
        }

    }
}
