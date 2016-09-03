using System;
using System.Collections.Generic;

namespace RPG_Go.DungeonMaster
{
    // look at this politically correct enum
    public enum genders
    {
        None, Male, Female, MTF, FTM, AttackHelicopter
    }

    public enum damageType
    {
        slash, poison, bludgeon, burn, freeze, acid
    }

    ///
    public enum bodyParts
    {
        Head, Neck, Torso, LeftArm, LeftHand, LeftLeg, LeftFoot, RightArm, RightHand, RightLeg, RightFoot
    }

    public class Entity
    {
        public string Name { get; set; }
        public genders Gender { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public Alignment Alignment { get; set; }
        public BaseAndBonus ArmorClass = new BaseAndBonus();

        /// <summary>
        /// The list loot this entity has
        /// </summary>
        public List<Item> Inventory { get { return _inventory; } }

        private List<Item> _inventory = new List<Item>();

        /// Ability scores & Sklls are encapsulated so they can be shared with other classes such as monsters
        public AbilityScores AbilityScores { get; set; }
    }
}