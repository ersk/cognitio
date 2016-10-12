using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    // idea, discovery, invention (knowledge)

    public class KnowledgeDb : ObjectDb  { }

    public class IdeaDb: KnowledgeDb
    {
        public List<KnowledgeDb> KnowledgePrerequisites { get; }
        public uint IdeaPointsNeeded { get; }
        public List<KnowledgeDb> KnowlegeUnlocks { get; }
    }

    public class DiscoveryDb
    {
        // animal / plant / race /location / mineral / climate
    }
    public class InventionDb 
    { 
        // item
    }
    public class DesignDb { }
}
