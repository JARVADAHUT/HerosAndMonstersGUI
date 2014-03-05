using DesignPatterns___DC_Design;
using MazeTest;
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
            Dictionary<EnumGearSlot, Equipable> PlayerEquipedInventory = Player.GetInstance().GetEquipedInventory();
            Equipable currentlyEquipedItem = PlayerEquipedInventory[Slot];
            StatAugmentCommand cmd = new StatAugmentCommand();

            // for each effect on current equiped item, add its inverse effect to cmd
            foreach (EffectInformation effect in currentlyEquipedItem.Properties)
            {
                cmd.AddEffect(effect.GetInverse(), Hero.GetInstance());
            }

            // apply inverse cmd to character to "unequpid" item. 
            StatAugmentManager.GetInstance().OfferCommand(cmd);

            //PlayerEquipedInventory.Remove[Slot];

            return true;
        }

        new public EnumItemType GetType()
        {
            return EnumItemType.Equipable;
        }



    }
}