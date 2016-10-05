using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model
{
    class Building
    {
        public List<Room> Rooms { get; set; }
        public BuildRequirements BuildRequirements { get; set; } 
    }

    class Room
    {
        public MinMax JobsMinMax { get; set; }
        public int MyProperty { get; set; }
    }

    class ProcessRoom : Room
    {
        public List<ItemMinMax> InputItemsMinMax { get; set; }
        public List<ItemMinMax> OutputItemsMinMax { get; set; }
        public MinMax ProcessTimeMinMax { get; set; }
    }



    class MinMax
    {
        public uint Min { get; set; }
        public uint Max { get; set; }

        //constructor, make sure max is atleast as big as min.
        // get random value
        // add curvature to number select
    }

    class BuildRequirements
    {
        public List<ItemMinMax> ResourcesMinMax { get; set; }
        public MinMax SpaceMinMax { get; set; }
    }


    class ItemMinMax : MinMax
    {
        public ItemTypeObject Item { get; set; }
    }


    class StorageModule : Module
    {
        public ItemContainer ItemContainer { get; set; }
    }

    class ProductionModule : Module
    {
        public List<ItemCount> InputItems { get; set; }
        public List<ItemCount> OutputItems { get; set; }
        public uint BaseProcessTime { get; set; }
    }






    class Module { }
}
