using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.crud
{
    using DungeonMaster;
    public class EffectCreate
    {
        
        public const string FilePath = @"C:\Users\John\Documents\visual studio 2015\Projects\RPG Go\RPG Go\Effects.json";

        public EffectCreate()
        {

            Effect e = new Effect("Dwarf", "OnCreate", @"
                Character c = (Character)sender;
                c.AbilityScores.Constitution += 2;
");

        }
    }
}
