﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    public class JobDb
    {
        public string Name { get; set; }
        public List<SkillDb> NeededSkills { get; set; }
    }
}
