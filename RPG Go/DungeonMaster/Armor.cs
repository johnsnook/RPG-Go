using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Go.DungeonMaster
{
    public class Armor : Item
    {
        public enum Types
        {
            Heavy, Medium, Light
        }

        public Types Type;

        public void PutOn(string Effect)
        {


        }

        public void TakeOff() { }
       
    }

    public class ChainMail:Armor
    {
        public ChainMail() {
            Name = "Chain Mail";

        }
        private ChainMail(string name, int weight, string description, Types type) {}

    }
}
