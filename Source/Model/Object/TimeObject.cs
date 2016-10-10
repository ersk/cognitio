using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class TimeObject : DbObject
    {
        private DateTime start;
        public DateTime Start { get { return start; } }

        private DateTime end;
        public DateTime End { get { return end; } }
    }


    public class MoveObject : TimeObject
    {
        private LocationObject toLocation;
        public LocationObject ToLocation { get { return toLocation; } }

        private LocationObject fromLocation;
        public LocationObject FromLocation { get { return fromLocation; } }

    }
    public class MoveItemObject : MoveObject
    {
        public ItemObjectList ItemList { get; set; }
    }
    public class CreateItemObject : MoveObject
    {
        public ItemObjectList UsedUpItemList { get; set; }
        public ItemObjectList CreatedItemList { get; set; }
    }


    //tile, building, room
    public class LocationObject : DbObject
    {

    }
}
