using System;

namespace RPG_Go.Player
{
    using DungeonMaster;
    
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
    /// <summary>
    /// The Character Class relies on Race and Class to to build
    /// </summary>
    public class Character
    {
        

        /// <summary>
        /// Events
        /// </summary>
        public event EventHandler Create;
        public event EventHandler LevelUp;
        //public event EventHandler Attack;
        //public event EventHandler Attacked;
        //public event EventHandler SavingThrow;
        //public event EventHandler SkillCheck;
        //public event EventHandler DifficultyCheck;

        /// <summary>
        /// Properties
        /// </summary>
        public string Name { get; set; }
        public genders Gender = genders.None;
        public int XP { get; }
        public int Level { get; }
        //        [JsonIgnore]
        private CharacterRace _race;
        public CharacterRace Race {
            get { return _race; }
            set {
                _race = value;
                //// Attach event handler code
                this.Create += _race.OnCreate;
            }
        }
        //        [JsonIgnore]
        private CharacterClass _class;
        public CharacterClass Class
        {
            get { return _class; }
            set
            {
                _class = value;
                //// Attach event handler code
                this.LevelUp += _class.OnLevelUp;
                this.Create += _class.OnCreate;
            }
        }

        public int MaxHitPoints { get; protected internal set; }
        public int CurrentHitPoints { get; protected internal set; }

        public Alignment Alignment { get; set; }

        /// Ability scores & Sklls are encapsulated so they can be shared with other classes such as monsters
        public AbilityScores AbilityScores { get; set; }
        public Skills Skills { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public Character()
        {
                
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <example>
        /// D = Dwarf.Instance;
        /// F = Fighter.Instance;
        /// C = new Character(D, F, Character.genders.MTF);
        /// </example>
        /// <param name="newCharacterRace"></param>
        /// <param name="newCharacterClass"></param>
        /// <param name="newGender"></param>
        // This will roll a new character based on a race and class
        public Character(CharacterRace newCharacterRace, CharacterClass newCharacterClass, genders newGender = genders.Female)
        {
            Console.WriteLine("non default Character constructor called");
            // Alignment = new Alignment();
            Gender = newGender;
            Race = newCharacterRace;
            Class = newCharacterClass;
            AbilityScores = new AbilityScores();
            Skills = new Skills();
            //// roll a list in decending order and map them to the most important abilities for that class            
            int[] list = Dice.ThreeD6(6, Dice.sort.descending);

            for (int i =0; i < 6; i++)
            {
                // plug the best score possible into the best attribute 
                AbilityScores[Class.abilityScoredPrecedence[i]] = list[i];
            }
            // generate a random name, player can change before save
            Name = RandomName();

            OnCreate(EventArgs.Empty);
        }


        /// <summary>
        /// Invoker for Create event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCreate(EventArgs e)
        {
            // Invokes the delegates. 
            Create?.Invoke(this, e);
        }

        /// <summary>
        /// Invoker for LevelUp event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnLevelUp(EventArgs e)
        {
            // Invokes the delegates. 
            LevelUp?.Invoke(this, e);
        }
        

        /// <summary>
        /// Generates a random name from the race names
        /// </summary>
        /// <returns>String Name</returns>
        private string RandomName()
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
