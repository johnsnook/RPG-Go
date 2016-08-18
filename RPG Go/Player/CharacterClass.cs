// Title: Class class for RPG_Go
// Author: John Snook
// Created 2016-08-16  

using System;
namespace RPG_Go.Player
{
    using System.Collections;

    // Confusing name, but this fella is the abstract for D&D class types, like Fighter, Cleric etc.
    public abstract class CharacterClass
    {

        private string name; // 'class name'
        private string description; // 'class description'
        protected internal string[] abilityScoredPrecedence;

        // All Properties are read only
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract void OnCreate(Object sender, EventArgs e);
        public abstract void OnLevelUp(Object sender, EventArgs e);


    }

}