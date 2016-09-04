namespace RPG_Go
{
    using System;
    using System.Collections.Generic;

    // Confusing name, but this fella is the abstract for D&D class types, like Fighter, Cleric etc.
    public abstract class CharacterClass
    {
        protected internal string[] abilityScoredPrecedence;

        /// <summary>
        /// The list of features this race has
        /// </summary>
        protected internal abstract List<Effect> Effects { get; }

        public abstract void ConnectEffects(Character character);

        // All Properties are read only
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract void OnCreate(Object sender, EventArgs e);

        public abstract void OnLevelUp(Object sender, EventArgs e);
    }
}