using RPG_Go;
using System;

namespace Constintine
{
    public class ConsoleUserInterface : IUserInterface
    {
        private static Action<string> cw = Console.WriteLine;
        private ConsoleColor color;

        public ConsoleUserInterface()
        {
            color = Console.ForegroundColor;
        }

        public int Choose(string Prompt, string[] Choices)
        {
            int i;
            int choice = -1;
            int n;
            bool isNumeric;

            while (choice < 0)
            {
                i = 1;
                Console.ForegroundColor = ConsoleColor.Cyan;
                cw(Prompt);
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (string s in Choices)
                {
                    cw(i + " - " + Choices[i++ - 1]);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Please type the number of your choice: ");
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out n))
                {
                    cw("");
                    if (n < Choices.Length + 1)
                        choice = n - 1;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        cw("Bad answer.");
                    }
                }
                else
                {
                    cw("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    cw("Bad answer.");
                }
                Console.ForegroundColor = color;
            }

            Log("You chose: " + Choices[choice]);

            return choice;
        }

        public void Log(string Message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            cw(Message);
            Console.ForegroundColor = color;
        }

        public void Popup(string Message)
        {
            cw(Message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            cw("Press any key to continue.");
            Console.ForegroundColor = color;
            Console.Read();
        }
    }
}