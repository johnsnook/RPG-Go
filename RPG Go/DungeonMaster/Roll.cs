namespace RPG_Go.DungeonMaster
{
    using Monster;
    using Player;
    using System;

    public enum die
    {
        d4 = 4,
        d6 = 6,
        d10 = 10,
        d12 = 12,
        d20 = 20,
        d100 = 100
    }

    public enum rollMod
    {
        None,
        Advantage,
        Disadvantage
    }

    public class Roll
    {
        public die Die { get; set; }
        public rollMod RollMod { get; set; }
        public int Bonus { get; set; }
        private const int _intnull = -9000;
        private int _rollValue = _intnull;

        public int Value
        {
            get
            {
                if (_rollValue == _intnull)
                {
                    _rollValue = Dice.Roll((int)Die);
                }
                return _rollValue;
            }
        }

        public event EventHandler RolledAOne;

        public event EventHandler RolledATwenty;

        /// Invokes the delegates.
        protected virtual void OnRolledAOne(EventArgs e) { RolledAOne?.Invoke(this, e); }

        /// Invokes the delegates.
        protected virtual void OnRolledATwenty(EventArgs e) { RolledATwenty?.Invoke(this, e); }
    }

    public class AttackRoll : Roll
    {
        private Entity Attacker { get; set; }
        private Entity Defender { get; set; }

        public AttackRoll(Entity attacker, Entity defender)
        {
            Attacker = attacker;
            Defender = defender;
        }
    }
}