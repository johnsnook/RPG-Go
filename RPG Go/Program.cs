using System;
using RPG_Go.PlayersHandbook;
namespace RPG_Go
{
    using System.Collections;
    class Program
    {

        static void Main(string[] args)
        {
            Action<string> cw = Console.WriteLine;
            bool done = false;
            while (!done)
            {
                
                cw("Butts");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "d":
                        Dwarf D = new Dwarf();
                        cw(D.Description);
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        cw("what?");
                        break;

                }
            }
            
        }

        void DoIt()
        {


        }
    }
}
