using System;

namespace RPG_Go.Player
{
    using DungeonMaster;

    /// <summary>
    /// The Character Class relies on Race and Class to to build.  It gets serialized and stored as JSON in characaters.json
    /// </summary>
    public class Character : Entity
    {
        /// <summary>
        /// Create event gets called after a new character is "rolled", allowing subscribers to modify a new level 1 character
        /// </summary>
        public event EventHandler Create;

        /// <summary>
        /// Create event, may not be needed really
        /// </summary>
        public event EventHandler LevelUp;

        //public event EventHandler Attack;
        //public event EventHandler Attacked;
        //public event EventHandler SavingThrow;
        //public event EventHandler SkillCheck;
        //public event EventHandler DifficultyCheck;

        /// Experience Points, readonly
        public int XP { get { return _XP; } }

        private int _XP = 0;

        /// Level, readonly
        public int Level { get { return _Level; } }

        private int _Level = 1;

        /// Level, readonly
        public int Speed { get { return _speed; } }

        protected internal int _speed = 1;
        private string _raceName;

        /// The name of the characters race that we use for display and lookup of the object itself
        public string RaceName
        {
            get { return _raceName; }
            set
            {
                _raceName = value;
                //// Attach event handler code
                CharacterRace race = GetRace();
                this.Create += race.OnCreate;
            }
        }

        private string _className;

        /// The name of the characters class that we use for display and lookup of the object itself
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                CharacterClass oclass = GetClass();
                //// Attach event handler code
                this.LevelUp += oclass.OnLevelUp;
                this.Create += oclass.OnCreate;
            }
        }

        /// The list of skill proficiencies for skill checks and whatnot
        public Skills Skills { get; set; }

        /// The list of languages
        public string[] Languages { get; protected internal set; }

        /// The list of tool, weapon or armor proficiencies
        public string[] Proficiencies { get; protected internal set; }

        /// <summary>
        /// Default constructor so serializtion ignores the main one
        /// We'll need to reatach any effects here, treat it as "onLoad"
        /// </summary>
        public Character()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <example>
        /// C = new Character("Dwarf", "Fighter", Character.genders.MTF);
        /// </example>
        /// <param name="raceName"></param>
        /// <param name="className"></param>
        /// <param name="gender"></param>
        // This will roll a new character based on a race and class
        public Character(string raceName, string className, genders gender = genders.Female)
        {
            Console.WriteLine("non default Character constructor called");
            // Alignment = new Alignment();
            Gender = gender;

            RaceName = raceName;
            ClassName = className;

            AbilityScores = new AbilityScores();
            Skills = new Skills();
            //// roll a list in decending order and map them to the most important abilities for that class
            int[] list = Dice.ThreeD6(6, Dice.sort.descending);

            for (int i = 0; i < 6; i++)
            {
                // plug the best score possible into the best attribute
                AbilityScores[GetClass().abilityScoredPrecedence[i]] = new BaseAndBonus(list[i]);
            }
            // generate a random name, player can change before save
            Name = RandomName();

            OnCreate(EventArgs.Empty);
        }

        /// Invoker for Create event
        protected virtual void OnCreate(EventArgs e) { Create.Invoke(this, e); }

        /// Invoker for LevelUp event
        protected virtual void OnLevelUp(EventArgs e) { LevelUp.Invoke(this, e); }

        private CharacterRace GetRace()
        {
            switch (_raceName)
            {
                case "Dwarf":
                    return new Dwarf();

                default:
                    return null;
            }
        }

        private CharacterClass GetClass()
        {
            switch (ClassName)
            {
                case "Fighter":
                    return new Fighter();

                default:
                    return null;
            }
        }

        /// <summary>
        /// Generates a random name from the race names
        /// </summary>
        /// <returns>String Name</returns>
        private string RandomName()
        {
            string[] First = new string[0];
            Random Rando = new Random();
            CharacterRace Race = GetRace();

            switch (Gender)
            {
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