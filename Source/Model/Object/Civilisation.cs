using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class CivilisationDb
    {
        public List<SettlementDb> Settlements { get; set; }
    }

    public class SettlementDb
    {
        public CivilisationDb Civilisation { get; set; }
    }

}
