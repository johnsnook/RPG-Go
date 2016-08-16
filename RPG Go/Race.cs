using System;
namespace RPG_Go
{
    namespace PlayersHandbook
    {
        using System.Collections;

        public abstract class Race
        {
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

        }

        public class Dwarf : Race
        {

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
}