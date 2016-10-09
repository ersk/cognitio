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
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public Construction Construction { get; set; }
    }

    class Room
    {
        public string Name { get; set; }
        public MinMax JobsMinMax { get; set; }
        public Construction Construction { get; set; }
    }

    class ProcessRoom : Room
    {
        public List<ItemMinMax> InputItemsMinMax { get; set; }
        public List<ItemMinMax> OutputItemsMinMax { get; set; }
        public MinMax ProcessTimeMinMax { get; set; } //;minutes
    }
    class StorageRoom : Room
    {
        public ItemContainer ItemContainer { get; set; }
    }
    class Construction
    {
        public List<ItemMinMax> ItemsMinMax { get; set; }
        public MinMax Time { get; set; }
        public MinMax Workers { get; set; }
        public MinMax Space { get; set; }
    }
    class Job
    {
        public string Name { get; set; }
        public List<Skill> NeededSkills { get; set; }
    }


    class MinMax
    {
        public uint Min { get; set; }
        public uint Max { get; set; }

        //constructor, make sure max is atleast as big as min.
        // get random value
        // add curvature to number select
    }




    class ItemMinMax : MinMax
    {
        public ItemTypeObject Item { get; set; }
    }


   

    class ProductionModule : Module
    {
        public List<ItemCount> InputItems { get; set; }
        public List<ItemCount> OutputItems { get; set; }
        public uint BaseProcessTime { get; set; }
    }






    class Module { }
}
