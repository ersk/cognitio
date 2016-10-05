using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model
{
    //class AnimalFactory
    //{
    //    public static Animal Create()
    //    {
    //        Animal animal = new Animal()
    //        {
    //            Attack = 3,
    //            Charge = 1,
    //            Courage = 5,
    //            Defence = 6,
    //            Fear = 0,
    //            Speed = 7,
    //            Stamina = 8,
    //            Toughness = 2,


    //        };

    //        Item foodItem = new FoodItem()
    //        {
    //            Name = "Food",
    //        };

    //        // food/animal
    //        Item animalItem = new FoodItem()
    //        {
    //            Name = "Animal",
    //        };

    //        // food/animal/dairy
    //        Item dairyItem = new FoodItem()
    //        {
    //            Name = "Dairy",
    //            Type = animalItem
    //        };

    //        // food/animal/dairy/milk
    //        Item milkItem = new FoodItem()
    //        {
    //            Name = "Milk",
    //            Size = 7,
    //            Weight = 14,
    //            Value = 4,
    //            Type = dairyItem
    //        };

    //        // food/animal/dairy/milk/cow_milk
    //        Item goatMilkItem = new FoodItem()
    //        {
    //            Type = milkItem,
    //            Name = "Goat Milk",
    //            Value = 4,
               
    //        };

    //        animal.MilkOutput = new List<ItemCount>()
    //        {
    //            new ItemCount
    //            {
    //                Item = goatMilkItem,
    //                Count = 6
    //            }
    //        };




    //        animal.ShearingOutput = new List<ItemCount>()
    //        {
    //            new ItemCount
    //            {
    //                Item = goatMilkItem,
    //                Count = 6
    //            }
    //        };

    //        return animal;


    //    }
    //}

    //class Animal : LivingStats
    //{
    //    // 4 llama milk? 4 milk?
    //    public List<ItemCount> MilkOutput { get; set; }

    //    // 6 eagle eggs? 6 egsg?
    //    public List<ItemCount> EggOutput { get; set; }

    //    // wool
    //    public List<ItemCount> ShearingOutput { get; set; }

    //    // Weapon/Accessory/Poison/SnakeVenom/CobraVenom
    //    // amount - 0.2 of a vile
    //    // time to take effect
    //    // effect? kills, makes ill etc
    //    public List<ItemCount> PoisonOutput { get; set; }

    //    /*
    //     * pelt
    //     * bones
    //     * ivory
    //     * scales
    //     * feathers
    //     * fur
    //     * oil
    //     * poison
    //     */
    //    // Clothing/Armour/LeatherArmour/LegLeatherArmourPiece
    //    public List<ItemCount> SlaughterOutput { get; set; }

    //    public uint Volatility { get; set; }
    //    public uint BreedRate { get; set; }
    //}



}
