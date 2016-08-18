using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.DungeonMaster
{
    public abstract class Item
    {
        public string Name { get; protected internal set; }
        public string Description { get; protected internal set; }

        public int Weight { get; protected internal set; }
    }
}
