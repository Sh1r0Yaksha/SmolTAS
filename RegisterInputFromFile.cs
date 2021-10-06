using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using SALT;

namespace SmolTAS
{
    public class RegisterInputFromFile
    {

        // Booleans to check key presses
        private static bool isDpressed = false; 
        private static bool isWpressed = false;
        private static bool isApressed = false;
        private static bool isSpressed = false;
        private static bool isUpPressed = false;
        private static bool isDownPressed = false;

        // Each line of the file is stored as a string

        public static List<string> recordedInputsList { get; set; }

        // Inputs folder in SALT\Mods folder
        private static string Inputs => FileSystem.GetMyPath() + "\\Inputs";

        private static readonly string[] empty = { string.Empty };

        // Creates a file in SALT\Mods folder
        public static void CreateTextFile()
        {
            if (!Directory.Exists(Inputs))
                Directory.CreateDirectory(Inputs);
            File.WriteAllLines(Inputs + "\\AO.txt", empty);
            File.WriteAllLines(Inputs + "\\AO.txt", empty);
            File.WriteAllLines(Inputs + "\\PoR.txt", empty);
            File.WriteAllLines(Inputs + "\\RH.txt", empty);
            File.WriteAllLines(Inputs + "\\PL.txt", empty);
            File.WriteAllLines(Inputs + "\\AOR.txt", empty);
            File.WriteAllLines(Inputs + "\\TTM.txt", empty);
            File.WriteAllLines(Inputs + "\\NO.txt", empty);
            File.WriteAllLines(Inputs + "\\MM.txt", empty);
            File.WriteAllLines(Inputs + "\\IM.txt", empty);
            File.WriteAllLines(Inputs + "\\RU.txt", empty);
            File.WriteAllLines(Inputs + "\\INA.txt", empty);
            File.WriteAllLines(Inputs + "\\HCH.txt", empty);
            File.WriteAllLines(Inputs + "\\REF.txt", empty);
            File.WriteAllLines(Inputs + "\\MAIN.txt", empty);
        }

        // Reads from a file named AO.txt in SALT\Mods folder
        public static void ReadFiles(Level level)
        {
            if (!Directory.Exists(Inputs))
                Directory.CreateDirectory(Inputs);

            string[] temp;
            switch (level)
            {
                case Level.MAIN_MENU:
                    temp = File.ReadAllLines(Inputs + "\\MAIN.txt");
                    break;

                case Level.OFFICE:
                    temp = File.ReadAllLines(Inputs + "\\AO.txt");
                    break;

                case Level.POP_ON_ROCKS:
                    temp = File.ReadAllLines(Inputs + "\\PoR.txt");
                    break;

                case Level.RED_HEART:
                    temp = File.ReadAllLines(Inputs + "\\RH.txt");
                    break;

                case Level.PEKO_LAND:
                    temp = File.ReadAllLines(Inputs + "\\PL.txt");
                    break;

                case Level.OFFICE_REVERSED:
                    temp = File.ReadAllLines(Inputs + "\\AOR.txt");
                    break;

                case Level.TO_THE_MOON:
                    temp = File.ReadAllLines(Inputs + "\\TTM.txt");
                    break;

                case Level.NOTHING:
                    temp = File.ReadAllLines(Inputs + "\\NO.txt");
                    break;

                case Level.MOGU_MOGU:
                    temp = File.ReadAllLines(Inputs + "\\MM.txt");
                    break;

                case Level.INUMORE:
                    temp = File.ReadAllLines(Inputs + "\\IM.txt");
                    break;

                case Level.RUSHIA:
                    temp = File.ReadAllLines(Inputs + "\\RU.txt");
                    break;

                case Level.INASCAPABLE_MADNESS:
                    temp = File.ReadAllLines(Inputs + "\\INA.txt");
                    break;

                case Level.HERE_COMES_HOPE:
                    temp = File.ReadAllLines(Inputs + "\\HCH.txt");
                    break;

                case Level.REFLECT:
                    temp = File.ReadAllLines(Inputs + "\\REF.txt");
                    break;

                default:
                    temp = empty;
                    break;
            }
            recordedInputsList = temp.ToList();
        }

        public static void ResetInputs()
        {
            isWpressed = false;
            isApressed = false;
            isSpressed = false;
            isDpressed = false;
            isUpPressed = false;
            isDownPressed = false;
        }


        // Method which checks which characters are in the text file and presses corresponding keys
        public static void DoInputs(int i)
        {
            if (recordedInputsList != null)
            {
                if (recordedInputsList[i].Contains('D') && !isDpressed)
                {
                    isDpressed = true;
                    VirtualInputs.SendDPressed();
                }
                if (!recordedInputsList[i].Contains('D') && isDpressed)
                {
                    isDpressed = false;
                    VirtualInputs.SendDPressed();
                    VirtualInputs.SendDReleased();
                }
                if (recordedInputsList[i].Contains('W') && !isWpressed)
                {
                    isWpressed = true;
                    VirtualInputs.SendWPressed();
                }
                if (!recordedInputsList[i].Contains('W') && isWpressed)
                {
                    isWpressed = false;
                    VirtualInputs.SendWPressed();
                    VirtualInputs.SendWReleased();
                }
                if (recordedInputsList[i].Contains('A') && !isApressed)
                {
                    isApressed = true;
                    VirtualInputs.SendAPressed();
                }
                if (!recordedInputsList[i].Contains('A') && isApressed)
                {
                    isApressed = false;
                    VirtualInputs.SendAPressed();
                    VirtualInputs.SendAReleased();
                }
                if (recordedInputsList[i].Contains('S') && !isSpressed)
                {
                    isSpressed = true;
                    VirtualInputs.SendSPressed();
                }
                if (!recordedInputsList[i].Contains('S') && isSpressed)
                {
                    isSpressed = false;
                    VirtualInputs.SendSPressed();
                    VirtualInputs.SendSReleased();
                }
                if (recordedInputsList[i].Contains('J') && !isUpPressed)
                {
                    isUpPressed = true;
                    VirtualInputs.SendUpPressed();
                }
                if (!recordedInputsList[i].Contains('J') && isUpPressed)
                {
                    isUpPressed = false;
                    VirtualInputs.SendUpPressed();
                    VirtualInputs.SendUpReleased();
                }
                if (recordedInputsList[i].Contains('G') && !isDownPressed)
                {
                    isDownPressed = true;
                    VirtualInputs.SendDownPressed();
                }
                if (!recordedInputsList[i].Contains('G') && isDownPressed)
                {
                    isDownPressed = false;
                    VirtualInputs.SendDownPressed();
                    VirtualInputs.SendDownReleased();
                }
            }
        }
    }
}
