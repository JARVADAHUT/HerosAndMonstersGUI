using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI
{
    public abstract class InventoryItem
    {

        public int Key { get; set; }
        public List<EffectInformation> Properties { private set; get; }
        protected String Description { get; set; }

        public InventoryItem(int key)
        {
            this.Key = key;
        }

        public abstract void Use();
        public abstract String GetDescription();
        new public abstract InventoryItemType GetType();

    }
}


/*
public EnumInventoryItemType Category { private set; get; }
public List<EffectInformation> Properties { private set; get; }
private IUseItemBehavior _useBehavior;

public InventoryItem(EnumInventoryItemType category)
{
    Category = category;
    Properties = new List<EffectInformation>();
}

public void AddEffect(EffectInformation effect)
{
    Properties.Add(effect);
}

        
public void RemoveEffect(StatsType stat)
{
    foreach (var x in _properties)
    {
        if (x._stat.Equals(stat))
            _properties.Remove(x);
    }
}
  

public void UseItem(Target targets)
{
    _useBehavior.UseItem(this,targets);
}

public void SetUseBehvaior(IUseItemBehavior behavior)
{
    _useBehavior = behavior;
}

*/