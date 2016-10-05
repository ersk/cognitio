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

        protected internal ItemObject(string name, ItemTypeObject type, uint size, uint weight)
            : base(name, type)
        {
            Size = size;
            Weight = weight;
        }

        public static ItemObject CreateItemObject(string name, ItemTypeObject type, uint size, uint weight)
        {
            ItemObject item = new ItemObject(name, type, size, weight);

            item.Store();

            return item;
        }
    }

    public class ItemTypeObject
    {
        public string Name { get; set; }
        public ItemTypeObject Type { get; set; }
        public List<ItemObject> Children { get; set; }

        protected internal ItemTypeObject(string name, ItemTypeObject type)
        {
            Name = name;
            Type = type;
        }

        internal void Store()
        {
            string dbFilePath = Config.DatabaseFilePath();
            IOdb db = OdbFactory.Open(dbFilePath);
            db.Store(this);
        }

        public static ItemTypeObject CreateRootItemObjectType(string name)
        {
            ItemTypeObject item = new ItemTypeObject(name, null);
            item.Store();
            return item;
        }
        public static ItemTypeObject CreateItemObjectType(string name, ItemTypeObject type)
        {
            ItemTypeObject item = new ItemTypeObject(name, type);
            item.Store();
            return item;
        }


    }

}

      
        
