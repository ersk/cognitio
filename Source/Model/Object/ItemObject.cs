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

        public static ItemObject CreateItemObject(IOdb db, string name, ItemTypeObject type, uint size, uint weight)
        {
            ItemObject item = new ItemObject(name, type, size, weight);

            //db.Store(item);
            type.Children.Add(item);
            db.Store(type);

            return item;
        }
    }



    public class ItemTypeObject : ObjectDb
    {
        private ItemTypeObject type;
        public ItemTypeObject Type { get { return type; } }

        public ItemObjectList Children { get; set; }

        protected internal ItemTypeObject(string name, ItemTypeObject type) : base(name)
        {
            this.type = type;
			Children = new ItemObjectList();
        }

        //internal void Store(object obj)
        //{
        //    string dbFilePath = Config.DatabaseFilePath();
        //    //IOdb db = OdbFactory.Open(dbFilePath);
        //    //db.Store(obj);
        //    //db.Close();
        //    ObjectDatabase.Store(obj);
        //}

        public static ItemTypeObject CreateRootItemObjectType(IOdb db, string name)
        {
            ItemTypeObject item = new ItemTypeObject(name, null);

            db.Store(item);

            return item;
        }
        public static ItemTypeObject CreateItemObjectType(IOdb db, string name, ItemTypeObject type)
        {
            ItemTypeObject item = new ItemTypeObject(name, type);
            //item.Store(item);

            //db.Store(item);
            type.Children.Add(item);
            db.Store(type);

            return item;
        }


    }


    public class ItemObjectList<T> : IEnumerable<T>
    {
        List<T> mylist = new List<T>();

        public T this[int index]
        {
            get { return mylist[index]; }
            set { mylist.Insert(index, value); }
        }

        public void Add(T item)
        {
            mylist.Add(item);
            ObjectDatabase.Store(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return mylist.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



    private class ItemCount
    {
        public ItemTypeObject Item { get; set; }
        public uint Count { get; set; }
    }
    private class ItemMinMax : MinMaxDb
    {
        public ItemTypeObject Item { get; set; }
    }




    //public class ItemObjectList : IEnumerable<ItemTypeObject>
    //{
    //    List<ItemTypeObject> mylist = new List<ItemTypeObject>();

    //    public ItemTypeObject this[int index]
    //    {
    //        get { return mylist[index]; }
    //        set { mylist.Insert(index, value); }
    //    }

    //    public void Add(ItemTypeObject item)
    //    {
    //        mylist.Add(item);
    //        ObjectDatabase.Store(this);
    //    }

    //    public IEnumerator<ItemTypeObject> GetEnumerator()
    //    {
    //        return mylist.GetEnumerator();
    //    }

    //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //    {
    //        return this.GetEnumerator();
    //    }
    //}


    //public class ItemObjectList : IEnumerable
    //{
    //    List<ItemTypeObject> m_Items = new List<ItemTypeObject>();

    //    public ItemObjectList()
    //    {
    //        // For the sake of simplicity lets keep them as arrays
    //        // ideally it should be link list
    //        m_Items = new List<ItemTypeObject>();
    //    }

    //    public void Add(ItemTypeObject item)
    //    {
    //        // Let us only worry about adding the item 
    //        m_Items.Add(item);
    //        Db4oDatabase.Store(this);
    //    }

    //    public int Count()
    //    {
    //        return m_Items.Count();
    //    }

    //    // IEnumerable Member
    //    public IEnumerator GetEnumerator()
    //    {
    //        foreach (object o in m_Items)
    //        {
    //            // Lets check for end of list (its bad code since we used arrays)
    //            if(o == null)
    //            {
    //                break;
    //            }

    //            // Return the current element and then on next function call 
    //            // resume from next element rather than starting all over again;
    //            yield return o;
    //        }
    //    }
    //}


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

      
        
