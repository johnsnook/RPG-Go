using System.Reflection;

namespace RPG_Go.DungeonMaster
{
    /// <summary>
    /// This class encapsulates the Ability Scores for characters, npcs AND monsters 
    /// </summary>
    public class AbilityScores
    {
        public int Strength { get;  set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

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

        public int Modifier(string propertyName)
        {
            int i = (int)this[propertyName];
            return (i - 10) / 2; ;
        }

    }
}
