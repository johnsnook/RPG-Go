﻿using System;

namespace RPG_Go.Player
{
    using RPG_Go.DungeonMaster;
    /// <summary>
    /// The Fighter Character Class
    /// </summary>
    public class Fighter : CharacterClass
    {
        // Lazily assign our instance to ourselves to keep it singletonish
        private static readonly Lazy<Fighter> lazy = new Lazy<Fighter>(() => new Fighter());
        public static Fighter Instance { get { return lazy.Value; } }

        public override void OnLevelUp(object sender, EventArgs e)
        {
            Character c = (Character)sender;
            c.MaxHitPoints += Dice.D10() + c.AbilityScores.Modifier("Constitution");

        }
        // Event should get called by the Character after rolling stats
        public override void OnCreate(object sender, EventArgs e)
        {
            Character c = (Character)sender;
            Random Rando = new Random();

            /// Hit Points at Higher Levels: 1d10 (or 6) + your Constitution modifier per fighter level after 1st
            c.MaxHitPoints = Dice.D10() ;

        }

        public Fighter()
        {
            abilityScoredPrecedence = new string[6] { "Strength", "Constitution", "Dexterity", "Wisdom", "Intelligence", "Charisma" };
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
