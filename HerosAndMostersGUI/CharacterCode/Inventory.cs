using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI
{

    public class Inventory : IEnumerable<InventoryItems>
    {

        private List<InventoryItems> _itemList;

        public Inventory()
        {
            _itemList = new List<InventoryItems>();
        }

        public void AddItem(InventoryItems item)
        {
            _itemList.Add(item);
        }

        public void AddItemList(IEnumerable<InventoryItems> items)
        {
            _itemList.AddRange(items);
        }

        /*
        public void RemoveItem(int key)
        {
            int index = 0;
            bool found = false;
            foreach (GenericItems i in itemList)
            {
                if (i.Key == key)
                    break;

                index++;
            }

            if (found)
                itemList.RemoveAt(index);
        }
        */

        public void RemoveItem(InventoryItems item)
        {
            _itemList.Remove(item);
        }

        internal List<InventoryItems> GetItems()
        {
            return _itemList;
        }

        // SORTING ALGORITHM - PARAMS: COMPARER <<OR>> STAT TYPE OR OTHER (possibly overload)


        public IEnumerator<InventoryItems> GetEnumerator()
        {
            return _itemList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Use(InventoryItems item)
        {
            bool remove = item.Use();
            if (remove)
                _itemList.Remove(item);
            
        }
    } // end class

} //end namespace



/*
public List<InventoryItem> GearList { private set; get; }
public List<InventoryItem> ConsumablesList { private set; get; }
public Dictionary<EnumInventoryItemType,InventoryItem> EquipedGearSet { private set; get; }
 
public Inventory()
{
    GearList = new List<InventoryItem>();
    ConsumablesList = new List<InventoryItem>();
}

public List<InventoryItem> SortInventory(Comparer<InventoryItem> comparer)
{
    var resultSet = new List<InventoryItem>();
    resultSet.AddRange(GearList);
    resultSet.AddRange(ConsumablesList);
    resultSet.Sort(comparer);

    return resultSet;
}

public void AddConsumables(params InventoryItem[] items)
{
    foreach(var x in items)
    {
        if(x.Category != EnumInventoryItemType.Consumable)
            throw new ArgumentException("You aren't using this correctly!");
        x.SetUseBehvaior(new ApplyEffectsUseBehavior());
        ConsumablesList.Add(x);
    }   
}

public void AddGear(params InventoryItem[] items)
{
    foreach (var x in items)
    {
        if(x.Category == EnumInventoryItemType.Consumable)
            throw new ArgumentException("You aren't using this correctly!");
        x.SetUseBehvaior(new ApplyEffectsUseBehavior());
        GearList.Add(x);
    }   
}

public void AddItems(params InventoryItem[] items)
{
    foreach (var x in items)
    {
        switch (x.Category)
        {
            case EnumInventoryItemType.Chest:
            case EnumInventoryItemType.Feet:
            case EnumInventoryItemType.Forearm:
            case EnumInventoryItemType.Head:
            case EnumInventoryItemType.Legs:
            case EnumInventoryItemType.Shoulders:
                AddGear(x);
                break;
            case EnumInventoryItemType.Consumable:
                AddConsumables(x);
                break;
        }
    }
}

public void UseConsumable(int index, Target targets)
{
    ConsumablesList[index].UseItem(targets);
    ConsumablesList.RemoveAt(index);
}

public void EquipGear(int index)
{
    if (EquipedGearSet.ContainsKey(GearList[index].Category))
    {
        UnEquipGear(GearList[index].Category);
    }
            
    GearList[index].UseItem(new Target(Hero.GetInstance()));
    GearList[index].SetUseBehvaior(new RemoveEffectsUseBehvaior());
    EquipedGearSet.Add(GearList[index].Category,GearList[index]);
}

public void UnEquipGear(EnumInventoryItemType type)
{
    if (EquipedGearSet.ContainsKey(type))
    {
        InventoryItem result = EquipedGearSet[type];
        EquipedGearSet.Remove(type);
        result.UseItem(new Target(Hero.GetInstance()));
        result.SetUseBehvaior(new ApplyEffectsUseBehavior());
        AddGear(result);
    }
}
*/