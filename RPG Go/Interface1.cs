using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Go
{
    internal interface IUserInterface
    {
        int Choose(string Prompt, string[] Choices);

        void Log(string Message);

        void Popup(string Message);
    }

    public class ConsoleUI : IUserInterface
    {
        public int Choose(string Prompt, string[] Choices)
        {
            int i = 0;
            int choice = -1;
            int n;
            bool isNumeric;

            while (choice < 0)
            {
                cw(Prompt);
                for(string s in Choices)
                {
                    cw(i + Choices[i++]);
                }
                cw('Please type the number of your choice: ')
                if (int.TryParse(Console.ReadLine(), out n))
                    choice = n;
            }
        }
    }
}