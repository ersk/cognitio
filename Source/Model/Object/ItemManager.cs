using Cognitio.Model.Group;
using Db4objects.Db4o;
using NDatabase;
using NDatabase.Api;
using NDatabase.Api.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class ItemManager
    {
        public static ItemGroup GetItemGroup()
        {
            string dbFilePath = Config.DatabaseFilePath();
            IOdb db = OdbFactory.Open(dbFilePath);

            IQuery query = db.Query<ItemGroup>();
            ItemGroup result = query.Execute<ItemGroup>().First();

            db.Close();

            return result;
        }

        public class AddItemTypeManagerModel
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }
        public class AddItemManagerModel : AddItemTypeManagerModel
        {
            public uint Weight { get; set; }
            public uint Size { get; set; }
        }
        public class AddFoodItemManagerModel : AddItemManagerModel
        {
            public uint FoodValue { get; set; }
        }

        public static void AddItem(AddItemTypeManagerModel model)
        {
            using (IOdb db = OdbFactory.Open(Config.DatabaseFilePath()))
            {
                IQuery query = db.Query<ItemTypeObject>();
                query.Descend("name").Constrain(model.Type).Equal();
                ItemTypeObject itemTypeObject = query.Execute<ItemTypeObject>().First();
                ItemTypeObject.CreateItemObjectType(db, model.Name, itemTypeObject);
            }
        }
        public static void AddItem(AddItemManagerModel model)
        {
            using (IOdb db = OdbFactory.Open(Config.DatabaseFilePath()))
            {
                IQuery query = db.Query<ItemTypeObject>();
                query.Descend("name").Constrain(model.Type).Equal();
                ItemTypeObject itemTypeObject = query.Execute<ItemTypeObject>().First();
                ItemTypeObject.CreateItemObjectType(db, model.Name, itemTypeObject);
            }
        }
        public static void AddItem(AddFoodItemManagerModel model)
        {
            // get type from database
            using(IOdb db = OdbFactory.Open(Config.DatabaseFilePath()))
            {
                IQuery query = db.Query<ItemTypeObject>();
                query.Descend("name").Constrain(model.Type).Equal();
                ItemTypeObject itemTypeObject = query.Execute<ItemTypeObject>().First();
                FoodItemObject.CreateFoodItemObject(db, model.Name, itemTypeObject, model.Size, model.Weight, model.FoodValue);
            }
        }
		
		public static ItemTypeObject GetItemTypeObject(string itemName)
        {
            ItemTypeObject result;

            using (IOdb db = OdbFactory.Open(Config.DatabaseFilePath()))
            {
                if (string.IsNullOrEmpty(itemName)) itemName = "_ROOT";
                IQuery query = db.Query<ItemTypeObject>();
                query.Descend("name").Constrain(itemName).Equal();
                result = query.Execute<ItemTypeObject>().First();
            }
			
            
       

            return result;
        }
		
		

        public static ItemObject GetItem(string typeString)
        {
            string dbFilePath = Config.DatabaseFilePath();
            IOdb db = OdbFactory.Open(dbFilePath);

            IQuery query = db.Query<ItemObject>();
            query.Descend("Name").Constrain("Food").Equal();
            ItemObject result = query.Execute<ItemObject>().First();

            db.Close();

            return result;
        }

        public static void CreateItemGroup()
        {
            using (IOdb db = OdbFactory.Open(Config.DatabaseFilePath()))
            {
                ItemTypeObject root = ItemObject.CreateRootItemObjectType(db, "_ROOT");

                #region items
                ItemTypeObject vehicle = ItemObject.CreateItemObjectType(db, "Vehicle", root);
                ItemTypeObject food = ItemObject.CreateItemObjectType(db, "Food", root);

                ItemObject chariot = ItemObject.CreateItemObject(db, "Chariot", vehicle, 81, 79);
                ItemObject.CreateItemObject(db, "Two By Two Chariot", chariot, 104, 98);
                ItemObject.CreateItemObject(db, "Erskish Chariot", chariot, 87, 73);


                ItemTypeObject animal = ItemTypeObject.CreateItemObjectType(db, "Animal", food);
                ItemTypeObject dairy = ItemTypeObject.CreateItemObjectType(db, "Dairy", animal);
                FoodItemObject.CreateFoodItemObject(db, "Egg", dairy, 2, 2, 6);
                FoodItemObject.CreateFoodItemObject(db, "Milk", dairy, 7, 9, 8);
                FoodItemObject.CreateFoodItemObject(db, "Butter", dairy, 3, 8, 7);

                ItemTypeObject meat = ItemTypeObject.CreateItemObjectType(db, "Meat", animal);
                FoodItemObject.CreateFoodItemObject(db, "Leg", meat, 17, 16, 8);
                ItemObject liver = FoodItemObject.CreateFoodItemObject(db, "Liver", meat, 2, 2, 36);
                FoodItemObject.CreateFoodItemObject(db, "Cow Liver", liver, 4, 4, 44);

                #endregion
            }
            
        }


    }

   

    public class ItemContainer
    {
        public List<ItemObject> Items { get; set; }

        public uint ItemSpace { get; set; }

        public bool AddItem(ItemObject addItem)
        {
            uint currSpaceUsed = 0;
            foreach (ItemObject currItem in Items)
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

        public bool TakeItem(int itemIndex, out ItemObject takeItem)
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
        public ItemObject Item { get; set; }
        public uint Count { get; set; }
    }

  
}
