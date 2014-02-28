using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.CharacterCode
{
    class Equipable : GenericItems
    {

        //private const int _propertyValues = 0;

        public Equipable(int key, List<EffectInformation> properties, String description)
            : base(key)
        {
            this.Key = key;
            this.Properties = properties;
            this.Description = description;
        }

        public void Use()
        {
            // swap
        }

        public String GetDescription()
        {
            return this.Description;
        }

        new public InventoryItemType GetType()
        {
            return InventoryItemType.Equipable;
        }



    }
}