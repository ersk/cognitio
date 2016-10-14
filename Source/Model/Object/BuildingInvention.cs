using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class BuildingInventionDb : ObjectDb
    {
        public List<RoomKnwoledgeDb> Rooms { get; }
        public ConstructionInventionDb Construction { get; }

        // health
    }

    // knowledge -> invention -> instance

    public class RoomInventionDb : ObjectDb
    {
        public uint Jobs {  set; }
        public ConstructionInventionDb Construction { get; }
    }

    public class ProcessInventionDb : RoomInventionDb
    {
        public List<ItemCount> InputItems { get; }
        public List<ItemCount> OutputItems { get; }
        public uint ProcessTime { get; } //;minutes
    }
    public class StorageInventionDb : RoomInventionDb
    {

    }
    public class ConstructionInventionDb
    {
        public List<ItemCount> Items { get; }
        public uint Time { get; }
        public uint Workers { get; }
        public uint Space { get; }
    }


  






    
}
