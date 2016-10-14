using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class CivilisationDb : ObjectDb
    {
        internal CivilisationDb(string name)
            : base(name)
        {

        }

        private List<SettlementDb> settlements { get; }
        public List<SettlementDb> Settlements { get{return settlements;} }
        public List<KnowledgeDb> KnowledgeKnown { get; }
        public List<KnowledgeDb> KnowledgeUnlocked { get; }
        public List<KnowledgeDb> KnowledgeUnknown { get; }

        public void AddSettlement(SettlementDb settlement)
        {
            // dont add if its already there
            bool exists = (bool?)(settlements.Where(s => s.Name == settlement.Name).Select(s => true).FirstOrDefault()) ?? false;
            if(exists == false)
            {
                settlements.Add(settlement);
            } 
        }
    }

    public class SettlementDb : ObjectDb
    {
        private CivilisationDb civilisation;
        public CivilisationDb Civilisation { get { return civilisation; } }

        private List<CitizenDb> citizens;
        public List<CitizenDb> Citizens { get { return citizens; } }

        internal SettlementDb(string name, CivilisationDb civ)
            : base(name)
        {
            civ.AddSettlement(this);
        }
    }

}
