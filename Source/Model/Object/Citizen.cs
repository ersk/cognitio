using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{

    class CitizenDb : ObjectDb
    {
        private RaceDb race;
        public RaceDb Race { get { return race; } }

        private SettlementDb homeSettlement;
        public SettlementDb HomeSettlement { get { return homeSettlement; } }

        private List<SkillDb> skills;
        public List<SkillDb> Skills { get { return skills; } }

        internal CitizenDb(string name, RaceDb race, SettlementDb homeSettlement)
            : base(name)
        {
            this.homeSettlement = homeSettlement;
            skills = new List<SkillDb>();

#warning Add citizen to settlement.citizens list.
        }
    }
}
