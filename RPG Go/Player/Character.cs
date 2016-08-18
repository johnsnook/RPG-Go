using System;

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
        // look at this politically correct enum
        public enum genders
        {
            None,
            Male,
            Female,
            MTF,
            FTM,
            AttackHelicopter
        }

        public event EventHandler Create;
        public event EventHandler LevelUp;

        public string Name { get; set; }
        public genders Gender = genders.None;
        public int XP { get; }
        public int Level { get; }
        public Alignment Alignment { get; set; }
        public CharacterRace Race { get; }
        public CharacterClass Class { get; }

        public int MaxHitPoints { get; protected internal set; }
        public int CurrentHitPoints { get; protected internal set; }

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
        public Character(CharacterRace newCharacterRace, CharacterClass newCharacterClass, genders newGender = genders.Female)
        {
            // Alignment = new Alignment();
            Gender = newGender;
            Race = newCharacterRace;
            Class = newCharacterClass;

            //// Attach event handler code
            this.Create += Race.OnCreate;
            this.LevelUp += Class.OnLevelUp;
            this.Create += Class.OnCreate;

            //// roll a list in decending order and map them to the most important abilities for that class            
            int[] list = Dice.ThreeD6(6, Dice.sort.descending);
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
            OnCreate(EventArgs.Empty);
            //Race.OnCreate(this, EventArgs.Empty);
        }

        // Event code?
        protected virtual void OnCreate(EventArgs e)
        {
            // Invokes the delegates. 
            Create?.Invoke(this, e);
        }
        protected virtual void OnLevelUp(EventArgs e)
        {
            // Invokes the delegates. 
            LevelUp?.Invoke(this, e);
        }
        public int Modifier(string propertyName)
        {
            int i = (int)this[propertyName];
            return (i - 10) / 2; ;
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
            string[] First = new string[0];
            Random Rando = new Random();
            switch (Gender){
                case genders.Male:
                case genders.FTM:
                    First = Race.MaleNames;
                    break;
                case genders.Female:
                case genders.MTF:
                    First = Race.FemaleNames;
                    break;
                case genders.None:
                    First = new string[Race.MaleNames.Length + Race.FemaleNames.Length];
                    Race.MaleNames.CopyTo(First, 0);
                    Race.FemaleNames.CopyTo(First, Race.MaleNames.Length);
                    
                    break;

            }

            return First[Rando.Next(First.Length)] + ' ' + Race.Surnames[Rando.Next(Race.Surnames.Length)];

        }

    }
}
