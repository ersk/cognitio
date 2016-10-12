using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    class RaceDb : LivingStatsDb
    {
        public uint Intelligence { get; set; }   
    }

    class SubRaceDb : RaceDb
    {
        // bonus stats
    }
}
