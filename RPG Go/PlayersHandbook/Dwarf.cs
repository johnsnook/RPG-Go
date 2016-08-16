using System;
namespace RPG_Go.PlayersHandbook
{
    using System.Collections;


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
