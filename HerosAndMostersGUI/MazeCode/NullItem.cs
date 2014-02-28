using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerosAndMostersGUI.MazeCode
{
    public class NullItem : InventoryItems
    {

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
    }
}
