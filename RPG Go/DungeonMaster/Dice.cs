using System;

namespace RPG_Go.DungeonMaster
{
    
    public class RPGEventArgs : EventArgs
    {
        public string Descripttion;
        
    }

    public class Dice
    {
        public enum sort
        {
            none,
            descending,
            ascending
        }
        static Random Rando = new Random();

        public static int D10()
        {
            return Rando.Next(1, 11); // creates a number between 1 and 20
        }

        public static int D20()
        {
            return Rando.Next(1, 21); // creates a number between 1 and 20
        }

        public static int[] D20(int count)
        {
            int[] rolls = new int[count];
            for (int i =0; i < count; i++)
            {
                rolls[i] = D20();
            }
            return rolls; 
        }

        // generates a number between 3 and 18
        public static int ThreeD6(){
            return Rando.Next(1, 7) + Rando.Next(1, 7) + Rando.Next(1, 7);
        }

        public static int[] ThreeD6(int count, sort sort = sort.none)
        {
            int[] rolls = new int[count];
            for (int i = 0; i < count; i++)
            {
                rolls[i] = ThreeD6();
            }

            switch (sort)
            {
                case sort.descending:
                    Array.Sort<int>(rolls,
                        new Comparison<int>(
                                (i1, i2) => i2.CompareTo(i1)
                        ));
                    break;

            }



            return rolls; 
        }

    }
}
