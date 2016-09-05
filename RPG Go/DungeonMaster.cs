using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Go
{
    public static class DungeonMaster
    {
        private static IUserInterface userInterface;

        private static IFileInterface fileInterface;

        public static IFileInterface FileInterface
        {
            get
            {
                return fileInterface;
            }

            set
            {
                fileInterface = value;
            }
        }

        public static IUserInterface UserInterface
        {
            get
            {
                return userInterface;
            }

            set
            {
                userInterface = value;
            }
        }
    }
}