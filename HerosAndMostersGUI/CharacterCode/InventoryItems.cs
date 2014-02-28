using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.CharacterCode
{
    interface InventoryItems
    {

        void Use();
        String GetDescription();
        InventoryItemType GetType();

    }
}
