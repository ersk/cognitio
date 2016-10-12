using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{

    class Citizen
    {
        public SettlementDb HomeSettlement { get; set; }
        public List<SkillDb> Skills { get; set; }
    }
}
