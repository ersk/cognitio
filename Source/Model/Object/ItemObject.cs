using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{

    public class ItemObject : ItemTypeObject
    {
        
        public uint Size { get; set; } // space the item takes up in storage
        public uint Weight { get; set; }

        private ItemObject(string name, ItemObject type, uint size, uint weight)
            : base(name, type)
        {
            Size = size;
            Weight = weight;
        }

        public static ItemObject CreateItemObject(string name, ItemObject type, uint size, uint weight)
        {
            ItemTypeObject item = new ItemObject(name, type, size, weight);
            item.Store();
            return item;
        }
    }

    public class ItemTypeObject
    {
        public string Name { get; set; }
        public ItemObject Type { get; set; }
        public List<ItemObject> Children { get; set; }

        private ItemTypeObject(string name, ItemObject type)
        {
            Name = name;
            Type = type;
        }

        protected void Store()
        {
            string dbFilePath = @"C:\Users\Ersk\Cognitio\cognitio.db";
            IOdb db = OdbFactory.Open(dbFilePath);
            db.Store(this);
        }

        public static ItemTypeObject CreateRootItemObjectType(string name)
        {
            ItemTypeObject item = new ItemTypeObject(name, null);
            item.Store();
            return item;
        }
        public ItemTypeObject CreateItemObjectType(string name, ItemObject type)
        {
            ItemTypeObject item = new ItemTypeObject(name, type);
            item.Store();
            return item;
        }
       
        
    }

}

      
        
