using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.Player
{
    [Serializable]
    public class Character
    {
        public event EventHandler OnCreate;

        public string Name;
        public string Gender;

        private CharacterRace characterRace;
        private CharacterClass characterClass;

        protected internal int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;

        // This will roll a new character based on a race and class
        public Character(CharacterRace newCharacterRace, CharacterClass newCharacterClass)
        {
            characterRace = newCharacterRace;
            
            
            characterRace.Create(this);
            characterClass = newCharacterClass;
        }

        
        /// attrsetter
        /// 
         

        ///////////  GETTERS 
        public CharacterRace Race
        {
            get { return characterRace; }
        }
        public CharacterClass Class
        {
            get { return characterClass; }
        }
        public int Strength
        {
            get { return strength; }
            //protected internal set { strength = value; }
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

    }
}
