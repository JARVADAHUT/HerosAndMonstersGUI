using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI
{
    public abstract class GenericItems : InventoryItems
    {

        public int Key { get; set; }
        public List<EffectInformation> Properties { set; get; }
        public String Description { get; set; }

        public GenericItems(int key)
        {
            this.Key = key;
        }


        public abstract bool Use();

        public string GetDescription()
        {
            return Description;
        }

        public new EnumItemType GetType()
        {
            throw new NotImplementedException();
        }
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