using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class BuildingKnowledgeDb : ObjectDb
    {
        public List<RoomKnwoledgeDb> Rooms { get; }
        public ConstructionKnowledgeDb Construction {  get; }
    }

    // knowledge -> invention -> instance

    public class RoomKnwoledgeDb : ObjectDb
    {
        public JobDb Job {  get; }
        public MinMaxDb JobsMinMax {  get; }
        public ConstructionKnowledgeDb Construction {  get; }
    }

    public class ProcessRoomKnowledgeDb : RoomKnwoledgeDb
    {
        public List<ItemMinMax> InputItemsMinMax {  get; }
        public List<ItemMinMax> OutputItemsMinMax {  get; }
        public MinMaxDb ProcessTimeMinMax {  get; } //;minutes
    }
    public class StorageRoomKnowledgeDb : RoomKnwoledgeDb
    {
        //public ItemContainer ItemContainer {  get; }
    }
    public class ConstructionKnowledgeDb
    {
        public List<ItemMinMax> ItemsMinMax {  get; }
        public MinMaxDb TimeMinMax {  get; }
        public MinMaxDb WorkersMinMax { get; }
        public MinMaxDb SpaceMinMax { get; }
    }


  






    
}
