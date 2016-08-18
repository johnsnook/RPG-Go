using System.Reflection;

namespace RPG_Go.DungeonMaster
{
    /// <summary>
    /// This class encapsulates the Ability Scores for characters, npcs AND monsters 
    /// </summary>
    public class AbilityScores
    {
        public int Strength { get; protected internal set; }
        public int Dexterity { get; protected internal set; }
        public int Constitution { get; protected internal set; }
        public int Intelligence { get; protected internal set; }
        public int Wisdom { get; protected internal set; }
        public int Charisma { get; protected internal set; }

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
