using System;
namespace RPG_Go
{
    namespace PlayersHandbook
    {
        using System.Collections;

        // Confusing name, but this fella is the abstract for D&D class types, like Fighter, Cleric etc.
        public abstract class Class
        {
            private string name; // 'class name'
            private string description; // 'class description'
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

        }
    }
}