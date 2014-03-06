using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerosAndMostersGUI.MazeCode
{
    public class NullItem : InventoryItems
    {
        //this will never actually be used anywhere, just make it think something was created
        public bool Use()
        {
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public new DesignPatterns___DC_Design.EnumItemType GetType()
        {
            throw new NotImplementedException();
        }

        public List<EffectInformation> GetProperties()
        {
            throw new NotImplementedException();
        }


        public EffectInformation GetProperty(DesignPatterns___DC_Design.StatsType type)
        {
            throw new NotImplementedException();
        }


        public void SetType(DesignPatterns___DC_Design.EnumItemType type)
        {
            throw new NotImplementedException();
        }


        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
