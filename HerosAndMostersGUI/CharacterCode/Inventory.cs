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
    public class Inventory
    {
        public List<InventoryItem> InventoryItems { private set; get; }

        public Inventory(params InventoryItem[] inventoryItems )
        {
            InventoryItems = new List<InventoryItem>(inventoryItems);
        }

        public Inventory()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public List<InventoryItem> GetInventorySource()
        {
            return InventoryItems;
        }

        public void SortInventory(Comparer<InventoryItem> comparer)
        {
            InventoryItems.Sort(comparer);
        }

        public void AddItem(params InventoryItem[] items)
        {
            foreach(var x in items)
            {
                InventoryItems.Add(x);
            }   
        }

        public void AddInventory(Inventory inventory)
        {
            InventoryItems.AddRange(inventory.InventoryItems);
        }

        public void AddItems(IEnumerable<InventoryItem> items)
        {
            InventoryItems.AddRange(items);
        }

        public void RemoveItem(InventoryItem item)
        {
            InventoryItems.Remove(item);
        }
    }
}
