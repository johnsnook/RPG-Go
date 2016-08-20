using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.DungeonMaster
{
    public class Weapon : Item
    {
        public enum Types
        {
            Simple, Melee, Ranged
        }

        public Types Type;

        public void Weild(string Effect)
        {
        }

        public void PutAway()
        {
        }
    }
}