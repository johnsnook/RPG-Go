using System;
namespace RPG_Go.Player
{
    /// this abstract defines the outline for the race base class
    public abstract class CharacterRace
    {
        /// Properties
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Size { get; }
        public abstract int Speed { get; }
        public abstract int StartingAge { get; }
        public abstract string[] MaleNames { get; }
        public abstract string[] FemaleNames { get; }
        public abstract string[] Surnames { get; }
        public abstract string[] Languages { get; }
        public abstract string[] Proficiencies { get; }

        /// Methods
        public abstract void OnCreate(Object sender, EventArgs e);

        
        
        //public abstract event EventHandler Create;
        //public abstract event EventHandler LevelUp;
        //public abstract event EventHandler Attack;
        //public abstract event EventHandler Attacked;
        //public abstract event EventHandler SavingThrow;
        //public abstract event EventHandler SkillCheck;
        //public abstract event EventHandler DifficultyCheck;

    }

}
