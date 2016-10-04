using Cognitio.Model.Group;
using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class ItemManager
    {
        public static List<ItemObject> GetItems()
        {
            
        }

        private static List<Item> CreateSomeItems()
        {
            List<Item> items = new List<Item>();

            #region items
            Item vehicle = new Item
            {
                Name = "Vehicle"
            };
            Item chariot = new Item
            {
                Name = "Chariot",
                Type = vehicle,
                Size = 81,
                Weight = 79
            };
            Item twoByTwoChariot = new Item
            {
                Name = "Two By Two Chariot",
                Type = chariot,
                Size = 104,
                Weight = 98
            };
            Item erskChariot = new Item
            {
                Name = "Erskish Chariot",
                Type = chariot,
                Size = 87,
                Weight = 73
            };

            Item food = new Item
            {
                Name = "Food"
            };
            Item animal = new Item
            {
                Name = "Animal",
                Type = food
            };
            Item dairy = new Item
            {
                Name = "Dairy",
                Type = animal
            };
            Item milk = new Item
            {
                Name = "Milk",
                Type = dairy,
                Size = 4,
                Weight = 7
            };
            Item butter = new Item
            {
                Name = "Butter",
                Type = dairy,
                Size = 3,
                Weight = 9
            };

            Item egg = new Item
            {
                Name = "Egg",
                Type = animal
            };

            Item meat = new Item
            {
                Name = "Meat",
                Type = animal
            };
            Item leg = new Item
            {
                Name = "Leg",
                Type = meat,
                Size = 17,
                Weight = 16
            };
            Item liver = new Item
            {
                Name = "Liver",
                Type = meat,
                Size = 2,
                Weight = 3
            };
            Item cowLiver = new Item
            {
                Name = "Cow Liver",
                Type = liver,
                Size = 4,
                Weight = 4
            };
            #endregion

            #region add
            items.Add(vehicle);
            items.Add(chariot);
            items.Add(twoByTwoChariot);
            items.Add(erskChariot);
            items.Add(food);
            items.Add(egg);
            items.Add(dairy);
            items.Add(meat);
            items.Add(milk);
            items.Add(butter);
            items.Add(leg);
            items.Add(liver);
            items.Add(cowLiver);
            items.Add(animal);
            #endregion

            return BuildHierarchy(items);
        }

        private static List<Item> BuildHierarchy(List<Item> items)
        {
            List<Item> topItems = items.Where(i => i.Type == null).ToList();



            foreach (Item itemType in topItems)
            {
                itemType.Children = BuildHierarchyLevel(items, itemType);
            }


            return topItems;
        }

        private static List<Item> BuildHierarchyLevel(List<Item> items, Item itemType)
        {
            List<Item> childItems = items.Where(i => i.Type == itemType).ToList();

            foreach (Item childItem in childItems)
            {
                childItem.Children = BuildHierarchyLevel(items, childItem);
            }

            return childItems;
        }
    }

   

    public class ItemContainer
    {
        public List<Item> Items { get; set; }

        public uint ItemSpace { get; set; }

        public bool AddItem(Item addItem)
        {
            uint currSpaceUsed = 0;
            foreach (Item currItem in Items)
            {
                currSpaceUsed += currItem.Size;
            }

            if (currSpaceUsed + addItem.Size <= ItemSpace)
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
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }

        }

        // space modifier?
    }


    public class ItemCount
    {
        public Item Item { get; set; }
        public uint Count { get; set; }
    }

  
}
