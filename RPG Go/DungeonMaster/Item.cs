namespace RPG_Go.DungeonMaster
{
    public abstract class Item
    {
        public string Name { get; protected internal set; }
        public string Description { get; protected internal set; }

        public int Weight { get; protected internal set; }
    }
}