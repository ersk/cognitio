using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Building
    {
        public List<Module> Modules { get; set; }
        public uint Space { get; set; }
    }


    class StorageModule : Module
    {
        public ItemContainer ItemContainer { get; set; }
    }

    class ProductionModule : Module
    {
        public List<ItemCount> InputItems { get; set; }
        public List<ItemCount> OutputItems { get; set; }
        public uint BaseProcessTime { get; set; }
    }

    class ItemContainer
    {
        public List<Item> Items { get; set; }

        public uint ItemSpace { get; set; }

        public bool AddItem(Item addItem)
        {
            uint currSpaceUsed = 0;
            foreach(Item currItem in Items)
            {
                currSpaceUsed += currItem.Size;
            }

            if(currSpaceUsed+ addItem.Size <= ItemSpace)
            {
                Items.Add(addItem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TakeItem(int itemIndex, out Item takeItem)
        {
            takeItem = null;

            try
            {
                takeItem = Items.ElementAt(itemIndex);
                Items.RemoveAt(itemIndex);
                return true;
            }
            catch(IndexOutOfRangeException ex)
            {
                return false;
            }
            
        }

        // space modifier?
    }


    class ItemCount
    {
        public Item Item { get; set; }
        public uint Count { get; set; }
    }
    class ItemType
    {
        public string Name { get; set; } //         weapon      sword       shortsword
        public ItemType Type { get; set; } //       item        weapon      sword
    }
    class Item 
    {
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        //public string Ancestory { get; set; } // build up ancestory details as string?
        public uint Size { get; set; } // space the item takes up in storage
        public uint Weight { get; set; }
    }

    class Module { }
}
