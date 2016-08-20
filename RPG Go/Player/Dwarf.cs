﻿using System;

namespace RPG_Go.Player
{
    using DungeonMaster;
    using System.Collections.Generic;

    /// <summary>
    /// Dwarf is race of characters.
    /// </summary>
    public class Dwarf : CharacterRace
    {
        // Lazily assign our instance to ourselves to keep it singletonish
        private static readonly Lazy<Dwarf> lazy = new Lazy<Dwarf>(() => new Dwarf());

        /// <summary>
        /// Returns a singleton instance of this class.  I'm not sure it needs to be a singleton anymore
        /// </summary>
        public static Dwarf Instance { get { return lazy.Value; } }

        /// <summary>
        /// The list of traits this race has
        /// </summary>
        public override List<Effect> Traits { get; set; } = new List<Effect>();

        /// Default constructor.  Attach yer Effects here to the traits bag
        public Dwarf()
        {
            TokenizedEffect te = new TokenizedEffect("dwarven_toughness", string.Empty, "Create", "char con +2");

            Traits.Add(te);
        }

        // Event should get called by the Character after rolling stats
        public override void OnCreate(object sender, EventArgs e)
        {
            Random Rando = new Random();

            /// Ability Score Increase: Your Constitution score increases by 2.
            Character c = (Character)sender;
            c.AbilityScores.Constitution.Bonus += 2;

            // alignment is sorta lawful good
            c.Alignment = new Alignment(Rando.Next(0, 11), Rando.Next(0, 11));
        }

        public virtual void OnLevelUp(object sender, EventArgs e)
        {
            //Character c = (Character)sender;
            //c.MaxHitPoints += Dice.D10();
        }

        /// <summary>
        /// Read only dwarf
        /// </summary>
        public override string Name { get; } = "Dwarf";

        /// <summary>
        /// Todo: write something less shitty
        /// </summary>
        public override string Description { get; } = "Short and tough, you have a lovely beard.";

        /// <summary>
        /// Size: Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium.
        /// </summary>
        public override string Size { get; } = "Medium";

        /// <summary>
        /// Speed: Your base walking speed is 25 feet. Your speed is not reduced by wearing Heavy Armor.
        /// </summary>
        public override int Speed { get; } = 25;

        /// <summary>
        /// Age: Dwarves mature at the same rate as humans, but they’re considered young until they reach the age of 50. On average, they live about 350 years.
        /// </summary>
        public override int StartingAge { get; } = 50;

        public override string[] MaleNames { get; } = new string[30] { "Adrik", "Alberich", "Baern", "Barendd", "Brottor", "Bruenor", "Dain", "Darrak", "Delg", "Eberk", "Einkil", "Fargrim", "Flint", "Gardain",
                    "Harbek", "Kildrak", "Morgran", "Orsik", "Oskar", "Rangrim", "Rurik", "Taklinn", "Thoradin", "Thorin", "Tordek", "Traubon", "Travok", "Ulfgar", "Veit", "Vondal"};

        public override string[] FemaleNames { get; } = new string[23] { "Amber", "Artin", "Audhild", "Bardryn", "Dagnal", "Diesa", "Eldeth", "Falkrunn", "Finellen", "Gunnloda", "Gurdis", "Helja", "Hlin", "Kathra",
                    "Kristryd", "Ilde", "Liftrasa", "Mardred", "Riswynn", "Sannl", "Torbera", "Torgga", "Vistra" };

        public override string[] Surnames { get; } = new string[15] { "Balderk", "Battlehammer", "Brawnanvil", "Dankil", "Fireforge", "Frostbeard", "Gorunn", "Holderhek", "Ironfst", "Loderr", "Lutgehr", "Rumnaheim",
                    "Strakeln", "Torunn", "Ungart" };

        public override string[] Languages { get; } = new string[2] { "Common", "Dwarvish" };

        public override string[] Proficiencies { get; } = new string[3] { "Stonecunning", "Darkvision", "Dwarven Toughness" };
    }
}