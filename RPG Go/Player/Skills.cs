using System.Reflection;

namespace RPG_Go.Player
{
    /// <summary>
    /// This class encapsulates the skills for characters
    /// </summary>
    public class Skills
    {
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