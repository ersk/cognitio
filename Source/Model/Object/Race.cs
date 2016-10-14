using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    class RaceDb : LivingStatsDb
    {
        private uint intelligence;
        public uint Intelligence { get { return intelligence; } }

        internal RaceDb(
            string name,
            uint charge,
            uint attack,
            uint defence,
            uint toughness,
            uint speed,
            uint stamina,
            uint courage,
            uint fear,
            uint breedRate,
            uint intelligence) : base( 
                name,
                charge,
                attack,
                defence,
                toughness,
                speed,
                stamina,
                courage,
                fear,
                breedRate)
        {
            this.intelligence = intelligence;
        }
    }

    class SubRaceDb : RaceDb
    {
        // bonus stats
    }
}
