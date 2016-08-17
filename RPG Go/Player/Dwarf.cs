﻿using System;
namespace RPG_Go.Player
{
    using System.Collections;

    // singleton
    public sealed class Dwarf : CharacterRace
    {
        private static readonly Lazy<Dwarf> lazy =
        new Lazy<Dwarf>(() => new Dwarf());

        public static Dwarf Instance { get { return lazy.Value; } }

        //public override event EventHandler LevelUp;
        //public override event EventHandler Attack;
        //public override event EventHandler Attacked;
        //public override event EventHandler SavingThrow;
        //public override event EventHandler SkillCheck;
        //public override event EventHandler DifficultyCheck;
        //public override event EventHandler OnCreate;

        public override void Create(Character character)
        {
            character.strength = 10;
        }

        public override string Name
        {
            get { return "Dwarf"; }
        }
        public override string Description
        {
            get { return "Short and tough, you have a lovely beard."; }
        }
        public override string Size
        {
            get { return "Medium"; }
        }
        public override int Speed
        {
            get { return 25; }
        }
        public override int StartingAge
        {
            get { return 50; }
        }
        public override ArrayList MaleNames
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");

                return list;
            }
        }
        public override ArrayList FemaleNames
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");

                return list;
            }
        }
        public override ArrayList Surnames
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");

                return list;
            }
        }
        public override ArrayList Languages
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");

                return list;
            }
        }
        public override ArrayList Proficiencies
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");

                return list;
            }
        }

    }
}