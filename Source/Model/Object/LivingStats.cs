using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitio.Model.Object
{
    class LivingStatsDb : ObjectDb
    {
        private uint charge;
        private uint attack;
        private uint defence;
        private uint toughness;
        private uint speed;
        private uint stamina;
        private uint courage;
        private uint fear;
        private uint breedRate;

        public uint Charge { get { return charge; } }
        public uint Attack { get { return attack; } }
        public uint Defence { get { return defence; } }
        public uint Toughness { get { return toughness; } }
        public uint Speed { get { return speed; } }
        public uint Stamina { get { return stamina; } }
        public uint Courage { get { return courage; } }
        public uint Fear { get { return fear; } }
        public uint BreedRate { get { return breedRate; } }

        internal LivingStatsDb(
            string name,
            uint charge,
            uint attack,
            uint defence,
            uint toughness,
            uint speed,
            uint stamina,
            uint courage,
            uint fear,
            uint breedRate) : base(name)
        {
            this.charge = charge;
            this.attack = attack;
            this.defence = defence;
            this.toughness = toughness;
            this.speed = speed;
            this.stamina = stamina;
            this.courage = courage;
            this.fear=fear;
            this.breedRate=breedRate;
        }
    }
}
