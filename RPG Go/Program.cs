using System;


namespace RPG_Go
{

    using RPG_Go.Player;
    using RPG_Go.DungeonMaster;
    using System.Collections;
    class Program
    {

        static void Main(string[] args)
        {
            Action<string> cw = Console.WriteLine;
            bool done = false;
            int[] list;
            Dwarf D;
            Fighter F;
            Character C;
            cw("Welcome to the RPG_Go testing suite.");
            while (!done)
            {
                Console.Write("RPG_Go: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "n":
                        D = Dwarf.Instance;
                        F = Fighter.Instance;
                        C = new Character(D, F, 'M');
                        

                        cw(C.ToString());
                        break;

                    case "d":
                        D = Dwarf.Instance;
                        cw(D.Description);
                        break;

                    case "r20":
                        list = Dice.D20(3);
                        cw("Rolling 3 d20: [" + list[0] + ',' + list[1] + ',' + list[2] + ']');
                        break;

                    case "r3d6":
                        list = Dice.ThreeD6(3, -1);
                        cw("Rolling 3 d20: [" + list[0] + ',' + list[1] + ',' + list[2] + ']');
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
