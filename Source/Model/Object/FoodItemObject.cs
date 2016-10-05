using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{

    public class FoodItemObject : ItemObject
    {
        
        public uint FoodValue { get; set; } 

        protected internal FoodItemObject(string name, ItemTypeObject type, uint size, uint weight, uint foodValue)
            : base(name, type, size, weight)
        {
            FoodValue = foodValue;
        }

        public static FoodItemObject CreateFoodItemObject(string name, ItemTypeObject type, uint size, uint weight, uint foodValue)
        {
            FoodItemObject item = new FoodItemObject(name, type, size, weight, foodValue);

            item.Store();

            return item;
        }
    }

}

      
        
