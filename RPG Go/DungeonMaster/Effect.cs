using System;
//using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace RPG_Go.DungeonMaster
{
    public class Effect
    {
        //public Object Parent;
        public string Name { get; protected internal set; }
        public string Description { get; protected internal set; }
        public string EventTrigger { get; protected internal set; }
        //public delegate E;

        //public abstract void OnEvent(object sender, EventArgs e);
        //public bool IsActive;
        //public int Duration;
    }

}
