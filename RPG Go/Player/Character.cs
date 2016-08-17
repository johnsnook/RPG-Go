using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.Player
{
    using RPG_Go.DungeonMaster;
    using System.Reflection;

    /// <summary>
    /// The Character Class relies on Race and Class to to build
    /// </summary>
    [Serializable]
    public class Character
    {
        public event EventHandler Create;

        public string Name;
        public char Gender = 'M';

        private CharacterRace characterRace;
        private CharacterClass characterClass;

        protected internal int strength;
        protected internal int dexterity;
        protected internal int constitution;
        protected internal int intelligence;
        protected internal int wisdom;
        protected internal int charisma;

        // This will roll a new character based on a race and class
        public Character(CharacterRace newCharacterRace, CharacterClass newCharacterClass, char newGender = 'F')
        {
            Gender = newGender;
            characterRace = newCharacterRace;
            characterClass = newCharacterClass;
            this.Create += characterRace.OnCreate;
            /// roll a list in decending order and map them to the most important abilities for that class            
            int[] list = Dice.ThreeD6(6, -1);
            for (int i =0; i < 6; i++)
            {
                switch (characterClass.abilityScoredPrecedence[i])
                {
                    case "strength":
                        strength = list[i];
                        break;
                    case "dexterity":
                        dexterity = list[i];
                        break;
                    case "constitution":
                        constitution = list[i];
                        break;
                    case "intelligence":
                        intelligence = list[i];
                        break;
                    case "wisdom":
                        wisdom = list[i];
                        break;
                    case "charisma":
                        charisma = list[i];
                        break;

                }

                Name = RandomName();

                //this[characterClass.abilityScoredPrecedence[i]] = list[i];
            }

            characterRace.OnCreate(this, EventArgs.Empty);
        }

        protected virtual void OnCreate(EventArgs e)
        {
            if (Create != null)
            {
                // Invokes the delegates. 
                Create(this, e);
            }
        }


        /*  GETTERS, mostly keeping it read-only */
        public CharacterRace Race { get { return characterRace; } }
        public CharacterClass Class { get { return characterClass; } }
        public int Strength
        {
            get { return strength; }
            //set { strength = value; }
        }
        public int Dexterity
        {
            get { return dexterity; } 
        }
        public int Constitution
        {
            get { return constitution; }
        }
        public int Intelligence
        {
            get { return intelligence; }
        }
        public int Wisdom
        {
            get { return wisdom; }
        }
        public int Charisma
        {
            get { return charisma; }
        }

        /// <summary>
        /// This allows me to set the ability scores by arbitrary name
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object this[string propertyName]
        {
            get
            {
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                return property.GetValue(this, null);
            }
            set
            {
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                property.SetValue(this, value, null);
            }
        }
        public override string ToString()
        {
            string s = "Name: " + Name + "\r\n"
                + "Gender: " + Gender + "\r\n"
                + "Race: " + characterRace.Name + "\r\n"
                + "Class: " + characterClass.Name + "\r\n"
                + "Strength: " + Strength + "\r\n"
                + "Dexterity: " + Dexterity + "\r\n"
                + "Constitution: " + Constitution + "\r\n"
                + "Intelligence: " + Intelligence + "\r\n"
                + "Wisdom: " + Wisdom + "\r\n"
                + "Charisma: " + Charisma + "\r\n";
            return base.ToString() + "\r\n" + s;
        }
        public string RandomName()
        {
            Random Rando = new Random();

            string[] First = Gender == 'M' ? characterRace.MaleNames : characterRace.FemaleNames;
            return First[Rando.Next(First.Length)] + ' ' + characterRace.Surnames[Rando.Next(characterRace.Surnames.Length)];

        }

    }
}
