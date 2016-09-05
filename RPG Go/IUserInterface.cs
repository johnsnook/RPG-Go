using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Go
{
    public interface IUserInterface
    {
        int Choose(string Prompt, string[] Choices);

        void Log(string Message);

        void Popup(string Message);
    }
}