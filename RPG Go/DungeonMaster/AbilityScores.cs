namespace RPG_Go.DungeonMaster
{
    using System;
    using System.Reflection;

    public class BaseAndBonus
    {
        public int Base { get { return _Base; } }
        private int _Base;
        public int Bonus { get { return _Bonus; } set { _Bonus = value; } }
        private int _Bonus;

        public int Modifier
        {
            get
            {
                decimal i = (Value - 10) / 2;
                return (int)Math.Floor(i);
            }
        }

        public string ModifierAsString
        {
            get
            {
                decimal i = (Value - 10) / 2;
                int j = (int)Math.Floor(i);
                string k = j > -1 ? '+' + j.ToString() : j.ToString();
                return k;
            }
        }

        // use this to get the total amount
        public int Value { get { return _Base + _Bonus; } }

        /// Dummy for serialization
        public BaseAndBonus() { }

        /// <summary>
        /// Constructor, sets base value
        /// </summary>
        /// <param name="BaseArg"></param>
        public BaseAndBonus(int value)
        {
            _Base = value;
        }
    }

    /// <summary>
    /// This class encapsulates the Ability Scores for characters, npcs AND monsters
    /// </summary>
    public class AbilityScores
    {
        public BaseAndBonus Strength { get; set; }
        public BaseAndBonus Dexterity { get; set; }
        public BaseAndBonus Constitution { get; set; }
        public BaseAndBonus Intelligence { get; set; }
        public BaseAndBonus Wisdom { get; set; }
        public BaseAndBonus Charisma { get; set; }

        /// <summary>
        /// This allows me to set the ability scores by arbitrary name
        ///
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object this[string propertyName]
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
    }
}