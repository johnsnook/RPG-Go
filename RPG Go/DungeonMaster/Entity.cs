using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.DungeonMaster
{
    // look at this politically correct enum
    public enum genders
    {
        None,
        Male,
        Female,
        MTF,
        FTM,
        AttackHelicopter
    }

    public class Entity
    {
        public string Name { get; set; }
        public genders Gender { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public Alignment Alignment { get; set; }

        /// Ability scores & Sklls are encapsulated so they can be shared with other classes such as monsters
        public AbilityScores AbilityScores { get; set; }
    }
}