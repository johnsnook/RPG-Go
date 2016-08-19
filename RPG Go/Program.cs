using System;

namespace RPG_Go
{

    using System.Collections;
    using Newtonsoft.Json;
    using System.IO;

    using Player;
    using DungeonMaster;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Main Program test loop
    /// </summary>
    class Program
    {
        static Action<string> cw = Console.WriteLine;

        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 160;
            TestUnits t; 

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("RPG_Go: ");
                Console.ForegroundColor = ConsoleColor.White;
                // get using input
                string command = Console.ReadLine();
                string[] words;

                words = command.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

                switch (words[0])
                {
                    case "help":
                        cw("Commands: test");
                        break;

                    case "test":
                        t = new TestUnits(words[1]);
                        break;


                    case "q":
                        return;


                    default:
                        cw("what?");
                        break;

                }
                

            }
        }

    }


    public class TestUnits
    {
        static Action<string> cw = Console.WriteLine;
        const string dudesPath = @"C:\Users\John\Documents\Visual Studio 2015\Projects\RPG Go\\RPG Go\dudes.json";

        public TestUnits(string test)
        {
            int[] list;
            Dwarf D;
            Fighter F;
            Character C;

            cw("Welcome to the RPG_Go testing suite.");
            while (true)
            {
                switch (test)
                {
                    case "n":
                        D = Dwarf.Instance;
                        F = Fighter.Instance;
                        C = new Character(D, F, genders.Male);

                        Console.ForegroundColor = ConsoleColor.Red;
                        cw(JsonConvert.SerializeObject(C, Formatting.Indented));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        cw(C.Alignment.ToString());
                        cw(C.AbilityScores.Modifier("Strength").ToString());
                        Console.ForegroundColor = ConsoleColor.White;


                        break;

                    case "d":
                        D = Dwarf.Instance;
                        cw(D.Description);
                        break;

                    case "wr":
                        writeCharacters();
                        break;

                    case "rr":
                        readCharacters();
                        break;

                    case "r20":
                        list = Dice.D20(3);
                        cw("Rolling 3 d20: [" + list[0] + ',' + list[1] + ',' + list[2] + ']');
                        break;

                    case "r3d6":
                        list = Dice.ThreeD6(3, Dice.sort.descending);
                        cw("Rolling 3 d20: [" + list[0] + ',' + list[1] + ',' + list[2] + ']');
                        break;

                    case "q":
                        return;


                    default:
                        cw("what?");
                        break;

                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("RPG_Go Testing: ");
                Console.ForegroundColor = ConsoleColor.White;
                // get using input
                test = Console.ReadLine();

            }


        }
        static void writeCharacters()
        {
            var dudes = new List<Character>();
            Dwarf D = Dwarf.Instance;
            Fighter F = Fighter.Instance;
            Character C = new Character(D, F, genders.MTF);
            dudes.Add(new Character(D, F, genders.Male));
            dudes.Add(new Character(D, F, genders.Female));
            dudes.Add(new Character(D, F, genders.None));
            dudes.Add(new Character(D, F, genders.Male));
            dudes.Add(new Character(D, F, genders.Male));

            JsonSerializer serializer = new JsonSerializer();
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            File.WriteAllText(dudesPath, JsonConvert.SerializeObject(dudes, settings));

            Character dude = dudes[0];
            Console.ForegroundColor = ConsoleColor.Yellow;
            cw(JsonConvert.SerializeObject(dude, settings));
            Console.ForegroundColor = ConsoleColor.White;

        }

        static void readCharacters()
        {

            //var dudes = new List<Character>();
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;



            List<Character> dudes = JsonConvert.DeserializeObject<List<Character>>(File.ReadAllText(dudesPath), settings);
            Character dude = dudes[0];
            //Console.ForegroundColor = ConsoleColor.Red;
            //cw(JsonConvert.SerializeObject(dude, Formatting.Indented));
            Console.ForegroundColor = ConsoleColor.Magenta;
            cw($"Name:               {dude.Name}");
            cw($"Alignment:          {dude.Alignment}");
            cw($"Strength:           {dude.AbilityScores.Strength}");
            cw("Strength Mod:       " + dude.AbilityScores.Modifier("Strength").ToString());
            cw($"Constitution:       {dude.AbilityScores.Strength}");
            cw($"Constitution Mod:   " + dude.AbilityScores.Modifier("Constitution").ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
