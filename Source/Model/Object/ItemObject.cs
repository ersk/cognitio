using NDatabase;
using NDatabase.Api;
using System;
using System.Collections;
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
        private string name;
        public string Name { get { return name; } }
        private ItemTypeObject type;
        public ItemTypeObject Type { get { return type; } }

        public ItemObjectList Children { get; set; }

        protected internal ItemTypeObject(string name, ItemTypeObject type)
        {
            this.name = name;
            this.type = type;
			Children = new ItemObjectList();
        }

        internal void Store()
        {
            string dbFilePath = Config.DatabaseFilePath();
            IOdb db = OdbFactory.Open(dbFilePath);
            db.Store(this);
            db.Close();
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




    public class ItemObjectList : IEnumerable
    {
        List<ItemTypeObject> m_Items = new List<ItemTypeObject>();

        public ItemObjectList()
        {
            // For the sake of simplicity lets keep them as arrays
            // ideally it should be link list
            m_Items = new List<ItemTypeObject>();
        }

        public void Add(ItemTypeObject item)
        {
            // Let us only worry about adding the item 
            m_Items.Add(item);
        }

        public int Count()
        {
            return m_Items.Count();
        }

        // IEnumerable Member
        public IEnumerator GetEnumerator()
        {
            foreach (object o in m_Items)
            {
                // Lets check for end of list (its bad code since we used arrays)
                if(o == null)
                {
                    break;
                }

                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return o;
            }
        }
    }


    //public class ItemObjectList : CollectionBase
    //{
    //    public ItemObjectList()
    //    {
    //        //
    //        // TODO: Add constructor logic here
    //        //
    //    }
    //    #region Properties
    //    /// <summary>
    //    /// Gets/Sets value for the item by that index
    //    /// </summary>
    //    public ItemTypeObject this[int index]
    //    {
    //        get
    //        {
    //            return (ItemTypeObject)this.List[index];
    //        }
    //        set
    //        {
    //            this.List[index] = value;
    //        }
    //    }
    //    #endregion

    //    #region Public Methods
    //    public int IndexOf(ItemTypeObject itemTypeObject)
    //    {
    //        if (itemTypeObject != null)
    //        {
    //            return base.List.IndexOf(itemTypeObject);
    //        }
    //        return -1;
    //    }
    //    public int Add(ItemTypeObject itemTypeObject)
    //    {
    //        if (itemTypeObject != null)
    //        {
    //            int returnInt = this.List.Add(itemTypeObject);
    //            Store();
    //            return returnInt;
    //        }
    //        return -1;
    //    }
    //    public void Remove(ItemTypeObject itemTypeObject)
    //    {
    //        this.InnerList.Remove(itemTypeObject);
    //        Store();
    //    }
    //    public void AddRange(ItemObjectList collection)
    //    {
    //        if (collection != null)
    //        {
    //            this.InnerList.AddRange(collection);
    //        }
    //        Store();
    //    }
    //    public void Insert(int index, ItemTypeObject itemTypeObject)
    //    {
    //        if (index <= List.Count && itemTypeObject != null)
    //        {
    //            this.List.Insert(index, itemTypeObject);
    //        }
    //        Store();
    //    }
    //    public bool Contains(ItemTypeObject itemTypeObject)
    //    {
    //        return this.List.Contains(itemTypeObject);
    //    }
    //    #endregion

    //    private void Store()
    //    {
    //        IOdb db = OdbFactory.Open(Config.DatabaseFilePath());
    //        db.Store(this);
    //        db.Close();
    //    }
    //}






}

      
        
