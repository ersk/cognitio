using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class DbObject
    {
        private string name;
        public string Name { get { return name; } }

        private bool locked;
        public bool Locked { get { return locked; } }

        protected internal DbObject(string name)
        {
            this.name = name;
            this.locked = false;
        }
    }
}
