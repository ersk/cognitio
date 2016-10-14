using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class BuildingInstanceDb
    {
        public string Name { get; }
        public List<RoomKnwoledgeDb> Rooms { get; }

        // current health
    }

    // knowledge -> invention -> instance

    public class RoomInstanceDb
    {
        List<Citizen> Workers { get; }
    }

    public class ProcessInstanceDb : RoomKnwoledgeDb
    {
        public List<ItemMinMax> InputItemsMinMax { get; }
        public List<ItemMinMax> OutputItemsMinMax { get; }
        public MinMaxDb ProcessTimeMinMax { get; } //;minutes
    }
    public class StorageInstanceDb : RoomKnwoledgeDb
    {
        //public ItemContainer ItemContainer { get; get; }
    }



  






    
}
