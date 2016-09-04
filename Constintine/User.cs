﻿using Newtonsoft.Json;
using System.IO;

namespace Constinetine
{
    using RPG_Go;

    internal class User
    {
        public string Name { set; get; }
        public Character Slot1 { set; get; }
        public Character Slot2 { set; get; }

        public User()
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