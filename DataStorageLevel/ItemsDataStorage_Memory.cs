using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataStorageLevel
{
    public class ItemsDataStorage_Memory
    {
        private const int MAX_ITEMS_NR = 50;
        private List<Item> iteme;

        private Item[] items;
        private int nrItems;

        public ItemsDataStorage_Memory()
        {
            items = new Item[MAX_ITEMS_NR];
            nrItems = 0;
        }

        public void AddItem(Item item)
        {
            items[nrItems] = item;
            nrItems++;
        }

        public List<Item> GetItems()
        {
            return iteme;
        }

        public Item[] SearchItemByName(string search)
        {
            List<Item> FoundItems = new List<Item>();
            foreach(Item item in items)
            {
                if(item != null && item.Name.ToLower() == search.ToLower())
                {
                    FoundItems.Add(item);
                }
            }
            return FoundItems.ToArray();
        }

        public Item[] SearchItemByDamage(int  damage)
        {
            List<Item> Founditems = new List<Item>();
            foreach(Item item in items) 
            {
                if(item != null && item.Damage == damage) 
                {
                    Founditems.Add(item);
                }
            }
            return Founditems.ToArray();
        }
    }
}
