using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Animal : LivingStats
    {
        // 4 llama milk? 4 milk?
        public List<ItemCount> MilkOutput { get; set; }

        // 6 eagle eggs? 6 egsg?
        public List<ItemCount> EggOutput { get; set; }

        // wool
        public List<ItemCount> ShearingOutput { get; set; }

        //venom
        public List<ItemCount> PoisonOutput { get; set; }

        /*
         * pelt
         * bones
         * ivory
         * scales
         * feathers
         * fur
         * oil
         * poison
         */
        public List<ItemCount> SlaughterOutput { get; set; }

        public uint Volatility { get; set; }
    }

    public enum FoodTypeEnum
    {
        Plant,
        Animal
    }

    /* Name
     * Type (parent)
     * Size
     * Weight
     */ 
    class FoodItem : Item
    {
        // egg = 3
        // carrot = 4
        // pig leg = 15
        public int Value { get; set; }
        public FoodTypeEnum Type { get; set; }
    }

    // food/animal/dairy/milk/cow_milk
    // food/animal/egg/eagle_egg

}
