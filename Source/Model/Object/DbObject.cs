using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class ObjectDb
    {
        private string name;
        public string Name { get { return name; } }

        private bool locked;
        public bool Locked { get { return locked; } }

        protected internal ObjectDb(string name)
        {
            this.name = name;
            this.locked = false;
        }
    }
}
