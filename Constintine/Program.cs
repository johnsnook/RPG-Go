﻿namespace Constintine
{
    using Newtonsoft.Json;
    using RPG_Go;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Main Program test loop
    /// </summary>
    internal class Program
    {
        private static Action<string> cw = Console.WriteLine;

        private static void Main(string[] args)
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 140;
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
                        if (words.Length > 1)
                            t = new TestUnits(words[1]);
                        else
                            t = new TestUnits("");
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
        private static Action<string> cw = Console.WriteLine;
        private const string dudesPath = @"C:\Users\John\Documents\Visual Studio 2015\Projects\RPG Go\\RPG Go\dudes.json";

        public TestUnits(string test)
        {
            int[] list;
            Dwarf D;
            Fighter F;
            CharacterSheet C;

            cw("Welcome to the RPG_Go testing suite.");
            while (true)
            {
                switch (test)
                {
                    case "c":
                        ConsoleUserInterface conny = new ConsoleUserInterface();
                        string[] choices = new string[3] { "Choice One", "Choice Two", "Choice 3" };
                        conny.Choose("What do you want?", choices);
                        break;

                    case "n":
                        D = new Dwarf();
                        F = new Fighter();
                        C = new CharacterSheet("Dwarf", "Fighter", genders.Male);

                        Console.ForegroundColor = ConsoleColor.Red;
                        cw(JsonConvert.SerializeObject(C, Formatting.Indented));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        cw(C.Alignment.ToString());
                        cw(C.AbilityScores.Strength.Modifier.ToString());
                        Console.ForegroundColor = ConsoleColor.White;

                        break;

                    case "d":
                        D = new Dwarf();
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

        private static void writeCharacters()
        {
            var dudes = new List<CharacterSheet>();
            Dwarf D = new Dwarf();
            Fighter F = new Fighter();
            CharacterSheet C = new CharacterSheet("Dwarf", "Fighter", genders.MTF);
            dudes.Add(new CharacterSheet("Dwarf", "Fighter", genders.Male));
            dudes.Add(new CharacterSheet("Dwarf", "Fighter", genders.Female));
            dudes.Add(new CharacterSheet("Dwarf", "Fighter", genders.None));
            dudes.Add(new CharacterSheet("Dwarf", "Fighter", genders.Male));
            dudes.Add(new CharacterSheet("Dwarf", "Fighter", genders.Male));

            JsonSerializer serializer = new JsonSerializer();
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            File.WriteAllText(dudesPath, JsonConvert.SerializeObject(dudes, settings));

            CharacterSheet dude = dudes[0];
            Console.ForegroundColor = ConsoleColor.Yellow;
            cw(JsonConvert.SerializeObject(dude, settings));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void readCharacters()
        {
            //var dudes = new List<Character>();
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            List<CharacterSheet> dudes = JsonConvert.DeserializeObject<List<CharacterSheet>>(File.ReadAllText(dudesPath), settings);
            CharacterSheet dude = dudes[0];
            //Console.ForegroundColor = ConsoleColor.Red;
            //cw(JsonConvert.SerializeObject(dude, Formatting.Indented));
            Console.ForegroundColor = ConsoleColor.Magenta;
            cw($"Name:               {dude.Name}");
            cw($"Alignment:          {dude.Alignment}");
            cw($"Strength:           {dude.AbilityScores.Strength.Value}");
            cw($"Strength Mod:       {dude.AbilityScores.Strength.Modifier}");
            cw($"Constitution:       {dude.AbilityScores.Strength.Value}");
            cw($"Constitution Mod:   " + dude.AbilityScores.Constitution.Modifier.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}