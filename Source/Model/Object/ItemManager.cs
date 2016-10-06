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
		
		public static ItemTypeObject GetItemTypeObject(string itemName)
        {
            //string dbFilePath = Config.DatabaseFilePath();
            //IOdb db = OdbFactory.Open(dbFilePath);
			
            //if(string.IsNullOrEmpty(itemName)) itemName = "_ROOT";
            //IQuery query = db.Query<ItemTypeObject>();
            //query.Descend("name").Constrain(itemName).Equal();
            //ItemTypeObject result = query.Execute<ItemTypeObject>().First();

            //db.Close();

            //return result;

            IObjectContainer db =
              Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), Config.DatabaseFilePath());
            IObjectSet result=null;
            try
            {
                ItemTypeObject proto = new ItemTypeObject("_ROOT", null);
                result = db.QueryByExample(proto);
                string s = "";
            }
            finally
            {
                db.Close();
            }

            var v = result[0];

            return (ItemTypeObject)v;
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
            ItemTypeObject root = ItemObject.CreateRootItemObjectType("_ROOT");

            #region items
            ItemTypeObject vehicle = ItemObject.CreateItemObjectType("Vehicle", root);
            ItemTypeObject food = ItemObject.CreateItemObjectType("Food", root);

            root.Children.Add(vehicle);
            root.Children.Add(food);

            //IOdb db = OdbFactory.Open(Config.DatabaseFilePath());
            //db.Store(root);
            //db.Store(vehicle);
            //db.Store(food);
            //db.Close();
            Db4oDatabase.Store(root);
            //Db4oDatabase.Store(vehicle);
            //Db4oDatabase.Store(food);


            ItemObject chariot = ItemObject.CreateItemObject("Chariot", vehicle, 81, 79);
            ItemObject.CreateItemObject("Two By Two Chariot", chariot, 104, 98);
            ItemObject.CreateItemObject("Erskish Chariot", chariot, 87, 73);


            ItemTypeObject animal = ItemTypeObject.CreateItemObjectType("Animal", food);
            ItemTypeObject dairy = ItemTypeObject.CreateItemObjectType("Dairy", animal);
            ItemObject.CreateItemObject("Egg", dairy, 2, 2);
            ItemObject.CreateItemObject("Milk", dairy, 7, 9);
            ItemObject.CreateItemObject("Butter", dairy, 3, 8);

            ItemTypeObject meat = ItemTypeObject.CreateItemObjectType("Meat", animal);
            ItemObject.CreateItemObject("Leg", meat, 17, 16);
            ItemObject liver = ItemObject.CreateItemObject("Liver", meat, 2, 2);
            ItemObject.CreateItemObject("Cow Liver", liver, 4, 4);

            #endregion

            //#region add
            //items.Add(vehicle);
            //items.Add(chariot);
            //items.Add(twoByTwoChariot);
            //items.Add(erskChariot);
            //items.Add(food);
            //items.Add(egg);
            //items.Add(dairy);
            //items.Add(meat);
            //items.Add(milk);
            //items.Add(butter);
            //items.Add(leg);
            //items.Add(liver);
            //items.Add(cowLiver);
            //items.Add(animal);
            //#endregion

            string dbFilePath = Config.DatabaseFilePath();

            //db.Store(itemGroup);
            
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
