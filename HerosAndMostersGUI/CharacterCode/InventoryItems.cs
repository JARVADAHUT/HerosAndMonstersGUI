using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.CharacterCode
{
    public interface InventoryItems
    {

        bool Use();
        String GetDescription();
        List<EffectInformation> GetProperties();
        EffectInformation GetProperty(StatsType type);
        EnumItemType GetType();

    }
}
