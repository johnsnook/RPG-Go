//using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace RPG_Go.DungeonMaster
{
    /// <summary>
    /// Base effect class
    /// </summary>
    public abstract class Effect
    {
        //public Object Parent;
        public abstract string Name { get; protected internal set; }

        public abstract string Description { get; protected internal set; }
        public abstract string EventTrigger { get; protected internal set; }
        //public delegate E;

        //public abstract void OnEvent(object sender, EventArgs e);
        //public bool IsActive;
        //public int Duration;
    }
}