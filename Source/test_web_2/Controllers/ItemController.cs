using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cognitio.Model;


namespace Cognitio.EditorWeb.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            List<Item> items = new List<Item>();


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

            List<Item> builtItems = BuildHierarchy(items);

            return View(builtItems);
        }

        private List<Item> BuildHierarchy(List<Item> items)
        {
            List<Item> topItems = items.Where(i => i.Type == null).ToList();



            foreach (Item itemType in topItems)
            {
                itemType.Children = BuildHierarchyLevel(items, itemType); 
            }


            return topItems;
        }

        private List<Item> BuildHierarchyLevel(List<Item> items, Item itemType)
        {
            List<Item> childItems = items.Where(i => i.Type == itemType).ToList();

            foreach (Item childItem in childItems)
            {
                childItem.Children = BuildHierarchyLevel(items, childItem);
            }

            return childItems;
        }
    }
}