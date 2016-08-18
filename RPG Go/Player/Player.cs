using Newtonsoft.Json;
using System.IO;

namespace RPG_Go.Player
{
    class Player
    {
        public string Name { set; get; }
        public Character Slot1 { set; get; }
        public Character Slot2 { set; get; }

        public Player()
        {
            Name = "John Snook";
        }

        public bool Save()
        {
            File.WriteAllText(@"c:\C:\Users\John\Documents\Visual Studio 2015\player.json", JsonConvert.SerializeObject(this));

            return true;
        }

        
    }
}
