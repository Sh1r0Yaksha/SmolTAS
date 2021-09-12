using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SmolTAS
{
    public class RegisterInputFromFile
    {
        public RegisterInputFromFile() { } //Constructor

        VirtualInputs virtualInputs = new VirtualInputs(); //Caliing VirtualInputs class

        // Booleans to check key presses
        private bool isDpressed = false; 
        private bool isWpressed = false;
        private bool isApressed = false;
        private bool isSpressed = false;
        private bool isUpPressed = false;
        private bool isDownPressed = false;

        // Each line of the file is stored as a string

        public List<String> recordedInputsList;


        // Creates a file in SALT\Mods folder
        public void CreateTextFile()
        {
            string[] space = { " " };
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\AO.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\PoR.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\RH.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\PL.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\AOR.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\TTM.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\NO.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\MM.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\IM.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\RU.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\INA.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\HCH.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\REF.txt", space);
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\MAIN.txt", space);
        }

        // Reads from a file named AO.txt in SALT\Mods folder
        public void ReadFiles(int i)
        {
            string[] temp = { "" };
            switch (i)
            {
                case 0:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\MAIN.txt");
                    break;

                case 1:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\AO.txt");
                    break;

                case 2:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\PoR.txt");
                    break;

                case 3:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\RH.txt");
                    break;

                case 4:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\PL.txt");
                    break;

                case 5:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\AOR.txt");
                    break;

                case 6:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\TTM.txt");
                    break;

                case 7:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\NO.txt");
                    break;

                case 8:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\MM.txt");
                    break;

                case 9:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\IM.txt");
                    break;

                case 10:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\RU.txt");
                    break;

                case 11:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\INA.txt");
                    break;

                case 12:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\HCH.txt");
                    break;

                case 13:
                    temp = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\Inputs\\REF.txt");
                    break;
            }
            recordedInputsList = new List<string>(temp);
        }

        public void ResetInputs()
        {
            isWpressed = false;
            isApressed = false;
            isSpressed = false;
            isDpressed = false;
            isUpPressed = false;
            isDownPressed = false;
        }


        // Method which checks which characters are in the text file and presses corresponding keys
        public void DoInputs(int i)
        {
            if (recordedInputsList != null)
            {
                if (recordedInputsList[i].Contains('D') && !isDpressed)
                {
                    isDpressed = true;
                    virtualInputs.SendDPressed();
                }
                if (!recordedInputsList[i].Contains('D') && isDpressed)
                {
                    isDpressed = false;
                    virtualInputs.SendDPressed();
                    virtualInputs.SendDReleased();
                }
                if (recordedInputsList[i].Contains('W') && !isWpressed)
                {
                    isWpressed = true;
                    virtualInputs.SendWPressed();
                }
                if (!recordedInputsList[i].Contains('W') && isWpressed)
                {
                    isWpressed = false;
                    virtualInputs.SendWPressed();
                    virtualInputs.SendWReleased();
                }
                if (recordedInputsList[i].Contains('A') && !isApressed)
                {
                    isApressed = true;
                    virtualInputs.SendAPressed();
                }
                if (!recordedInputsList[i].Contains('A') && isApressed)
                {
                    isApressed = false;
                    virtualInputs.SendAPressed();
                    virtualInputs.SendAReleased();
                }
                if (recordedInputsList[i].Contains('S') && !isSpressed)
                {
                    isSpressed = true;
                    virtualInputs.SendSPressed();
                }
                if (!recordedInputsList[i].Contains('S') && isSpressed)
                {
                    isSpressed = false;
                    virtualInputs.SendSPressed();
                    virtualInputs.SendSReleased();
                }
                if (recordedInputsList[i].Contains('J') && !isUpPressed)
                {
                    isUpPressed = true;
                    virtualInputs.SendUpPressed();
                }
                if (!recordedInputsList[i].Contains('J') && isUpPressed)
                {
                    isUpPressed = false;
                    virtualInputs.SendUpPressed();
                    virtualInputs.SendUpReleased();
                }
                if (recordedInputsList[i].Contains('G') && !isDownPressed)
                {
                    isDownPressed = true;
                    virtualInputs.SendDownPressed();
                }
                if (!recordedInputsList[i].Contains('G') && isDownPressed)
                {
                    isDownPressed = false;
                    virtualInputs.SendDownPressed();
                    virtualInputs.SendDownReleased();
                }
            }
        }
    }
}
