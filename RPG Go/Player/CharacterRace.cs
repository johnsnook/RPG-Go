﻿using System;
namespace RPG_Go.Player
{
    using System.Collections;


    // The race is on!  this abstract defines the outline for the race class
    public abstract class CharacterRace
    {
        //public abstract event EventHandler Create;
        public abstract void Create(Character character);
        //public abstract event EventHandler LevelUp;
        //public abstract event EventHandler Attack;
        //public abstract event EventHandler Attacked;
        //public abstract event EventHandler SavingThrow;
        //public abstract event EventHandler SkillCheck;
        //public abstract event EventHandler DifficultyCheck;

        private string name; // 'race name'
        private string description; // 'race description'
        private string size; // 'medium'
        private int speed; // 30
        private int startingAge; // 20
        private ArrayList maleNames;
        private ArrayList femaleNames;
        private ArrayList surnames;
        private ArrayList languages;
        private ArrayList proficiencies;

        // Properties
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Size { get; }
        public abstract int Speed { get; }
        public abstract int StartingAge { get; }
        public abstract ArrayList MaleNames { get; }
        public abstract ArrayList FemaleNames { get; }
        public abstract ArrayList Surnames { get; }
        public abstract ArrayList Languages { get; }
        public abstract ArrayList Proficiencies { get; }

        //public abstract void OnCreate(Object sender, System.EventArgs e);
    }

}