using Cognitio.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model
{
    public class Setup
    {
        public static void Run()
        {
            // open db and save

            CivilisationDb erskCiv = new CivilisationDb("Erskalonia");
            SettlementDb set = new SettlementDb("Ersk", erskCiv);

            RaceDb human = new RaceDb("Human", 4, 4, 4, 4, 4, 4, 4, 4, 6, 4);

            for(int i=0;i<10;i++)
            {
                new CitizenDb("Citizen 1", human, set);
            }


            //close db
        }
    }
}
