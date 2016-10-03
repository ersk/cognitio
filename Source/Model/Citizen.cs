using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model
{
    public enum SkillTypeEnum
    {
        Wood,
        Metal,
        Mineral,
        TradeAndStorage,
        Mlitary,
        Law,
        Maritime,
        ConstructionAndNavigation,
        Health,
        Culture,
        Knowledge,
        Entertainment
    }

    
    class Skill
    {
        public SkillTypeEnum Type { get; set; }
        public SkillLevel Level { get; set; }
    }

    class Citizen
    {
        public List<Skill> Skills { get; set; }
    }
}
