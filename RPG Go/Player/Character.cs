using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.Player
{
    using RPG_Go.DungeonMaster;
    using System.Reflection;

    public class Alignment
    {
        public int OrderAxis // -10 to 10, negative is chaotic, positive is lawful
        {
            get { return OrderAxis; }
            set {
                if (value < -10)
                {
                    OrderAxis = -10;
                }
                else if (value > 10)
                {
                    OrderAxis = 10;
                }
                else
                    OrderAxis = value;
            }
        }

        public int MoralAxis // -10 to 10, negative is evil, positive is good
        {
            get { return MoralAxis; }
            set
            {
                if (value < -10)
                {
                    MoralAxis = -10;
                }
                else if (value > 10)
                {
                    MoralAxis = 10;
                }
                else
                    MoralAxis = value;
            }
        }

        public Alignment(int orderAxis, int moralAxis)
        {
            OrderAxis = orderAxis;
            MoralAxis = moralAxis;
        }
    }

    /// <summary>
    /// The Character Class relies on Race and Class to to build
    /// </summary>
    [Serializable]
    public class Character
    {
        public event EventHandler Create;

        public string Name { get; set; }
        public char Gender = 'M';
        public int XP { get; }
        public int Level { get; }
        public Alignment Alignment { get; set; }
        public CharacterRace Race { get; }
        public CharacterClass Class { get; }

        /// Ability scores
        public int Strength { get; protected internal set; }
        public int Dexterity { get; protected internal set; }
        public int Constitution { get; protected internal set; }
        public int Intelligence { get; protected internal set; }
        public int Wisdom { get; protected internal set; }
        public int Charisma { get; protected internal set; }

        /// Skills
        public int Acrobatics { get; protected internal set; }
        public int AnimalHandling { get; protected internal set; }
        public int Arcana { get; protected internal set; }
        public int Athletics { get; protected internal set; }
        public int Deception { get; protected internal set; }
        public int History { get; protected internal set; }
        public int Insight { get; protected internal set; }
        public int Intimidation { get; protected internal set; }
        public int Investigation { get; protected internal set; }
        public int Medicine { get; protected internal set; }
        public int Nature { get; protected internal set; }
        public int Perception { get; protected internal set; }
        public int Performance { get; protected internal set; }
        public int Persuasion { get; protected internal set; }
        public int Religion { get; protected internal set; }
        public int SleightOfHand { get; protected internal set; }
        public int Stealth { get; protected internal set; }
        public int Survival { get; protected internal set; }

        //public override event EventHandler OnCreate;
        //public override event EventHandler LevelUp;
        //public override event EventHandler Attack;
        //public override event EventHandler Attacked;
        //public override event EventHandler SavingThrow;
        //public override event EventHandler SkillCheck;
        //public override event EventHandler DifficultyCheck;


        // This will roll a new character based on a race and class
        public Character(CharacterRace newCharacterRace, CharacterClass newCharacterClass, char newGender = 'F')
        {
            //Alignment = new Alignment();
            Gender = newGender;
            Race = newCharacterRace;
            Class = newCharacterClass;
            this.Create += Race.OnCreate;
            /// roll a list in decending order and map them to the most important abilities for that class            
            int[] list = Dice.ThreeD6(6, -1);
            for (int i =0; i < 6; i++)
            {
                switch (Class.abilityScoredPrecedence[i])
                {
                    case "strength":
                        Strength = list[i];
                        break;
                    case "dexterity":
                        Dexterity = list[i];
                        break;
                    case "constitution":
                        Constitution = list[i];
                        break;
                    case "intelligence":
                        Intelligence = list[i];
                        break;
                    case "wisdom":
                        Wisdom = list[i];
                        break;
                    case "charisma":
                        Charisma = list[i];
                        break;

                }

                Name = RandomName();

                //this[Class.abilityScoredPrecedence[i]] = list[i];
            }

            Race.OnCreate(this, EventArgs.Empty);
        }

        protected virtual void OnCreate(EventArgs e)
        {
            if (Create != null)
            {
                // Invokes the delegates. 
                Create(this, e);
            }
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

        public string RandomName()
        {
            Random Rando = new Random();

            string[] First = Gender == 'M' ? Race.MaleNames : Race.FemaleNames;
            return First[Rando.Next(First.Length)] + ' ' + Race.Surnames[Rando.Next(Race.Surnames.Length)];

        }

    }
}
