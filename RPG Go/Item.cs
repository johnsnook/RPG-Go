namespace RPG_Go
{
    using System.Collections.Generic;

    public abstract class Item
    {
        public string Name { get; protected internal set; }
        public string Description { get; protected internal set; }

        public int Weight { get; protected internal set; }

        /// <summary>
        /// The list of traits this item has
        /// </summary>
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
}