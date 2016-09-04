using System;

namespace RPG_Go
{
    public class RPGEventArgs : EventArgs
    {
        public string Descripttion;
    }

    public static class Dice
    {
        public enum sort
        {
            none,
            descending,
            ascending
        }

        private static Random Rando = new Random();

        /// <summary>
        /// Generic die rolling method
        /// </summary>
        /// <param name="sides">the max random number to return</param>
        /// <returns>and integer between one and "sides"</returns>
        public static int Roll(int sides)
        {
            return Rando.Next(1, sides + 1);
        }

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
            for (int i = 0; i < count; i++)
            {
                rolls[i] = D20();
            }
            return rolls;
        }

        // generates a number between 3 and 18
        public static int ThreeD6()
        {
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