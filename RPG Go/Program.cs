using System;

namespace RPG_Go
{

    using RPG_Go.Player;
    using RPG_Go.DungeonMaster;
    using System.Collections;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Main Program test loop
    /// </summary>
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
                        C = new Character(D, F, Character.genders.MTF);

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

                    case "nf":
                        D = Dwarf.Instance;
                        F = Fighter.Instance;
                        C = new Character(D, F, Character.genders.MTF);
                        JsonSerializer serializer = new JsonSerializer();
                        //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                        serializer.NullValueHandling = NullValueHandling.Ignore;
                        serializer.Formatting = Formatting.Indented;
                        serializer.

                        using (StreamWriter sw = new StreamWriter(@"C:\Users\John\Documents\Visual Studio 2015\characters.json", true))
                        using(JsonWriter writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, C);
                            // {"ExpiryDate":new Date(1230375600000),"Price":0}
                            cw("c:\\json.txt: " + sw);
                        }
                        
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
