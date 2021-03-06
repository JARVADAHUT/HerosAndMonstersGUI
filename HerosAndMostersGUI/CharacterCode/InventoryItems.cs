﻿using DesignPatterns___DC_Design;
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
        String GetName();
        List<EffectInformation> GetProperties();
        EffectInformation GetProperty(StatsType type);
        void SetType(EnumItemType type);
        EnumItemType GetType();
    }
}
