using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.Player
{
    /// <summary>
    /// The Fighter Character Class
    /// </summary>
    public class Fighter : CharacterClass
    {
        // Lazily assign our instance to ourselves to keep it singletonish
        private static readonly Lazy<Fighter> lazy = new Lazy<Fighter>(() => new Fighter());
        public static Fighter Instance { get { return lazy.Value; } }

        public Fighter()
        {
            abilityScoredPrecedence = new string[6] { "strength", "constitution", "dexterity", "wisdom", "intelligence", "charisma" };
        }
        public override void Create(Character character)
        {
            
            character.strength = 10;
        }
        public override string Name
        {
            get { return "Fighter"; }
        }
        public override string Description
        {
            get {
                return "Fighters learn the basics of all combat styles. Every fighter can swing an axe, fence with a rapier, " 
                    + "wield a longsword or a greatsword, use a bow, and even trap foes in a net with some degree of skill. "
                    + "Likewise, a fighter is adept with shields and every form of armor. Beyond that basic degree of familiarity, "
                    + "every fighter specializes in certain styles of combat. Some concentrate on archery, some on fighting with "
                    + "two weapons at once, and some on augmenting their martial skills with magic. This combination of broad "
                    + "general ability and extensive specialization makes fighters superior combatants on battlefields and in dungeons alike.";
            }
        }
    }
}
