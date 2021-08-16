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
        public string[] recordedInputs = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\AO.txt");
        

        // Creates a file in SALT\Mods folder
        public void CreateAOTextFile()
        {
            File.WriteAllLines(@SALT.FileSystem.GetMyPath() + "\\AO.txt", null);
        }

        // Reads from a file named AO.txt in SALT\Mods folder
        public void ReadAOFiles()
        {
            recordedInputs = File.ReadAllLines(@SALT.FileSystem.GetMyPath() + "\\AO.txt");
        }


        // Method which checks which characters are in the text file and presses corresponding keys
        public void DoInputs(int i)
        {
           
            if (recordedInputs[i].Contains('D') && !isDpressed)
            {
                isDpressed = true;
                virtualInputs.SendDPressed();
            }
            if (!recordedInputs[i].Contains('D') && isDpressed)
            {
                isDpressed = false;
                virtualInputs.SendDPressed();
                virtualInputs.SendDReleased();
            }
            if (recordedInputs[i].Contains('W') && !isWpressed)
            {
                isWpressed = true;
                virtualInputs.SendWPressed();
            }
            if (!recordedInputs[i].Contains('W') && isWpressed)
            {
                isWpressed = false;
                virtualInputs.SendWPressed();
                virtualInputs.SendWReleased();
            }
            if (recordedInputs[i].Contains('A') && !isApressed)
            {
                isApressed = true;
                virtualInputs.SendAPressed();
            }
            if (!recordedInputs[i].Contains('A') && isApressed)
            {
                isApressed = false;
                virtualInputs.SendAPressed();
                virtualInputs.SendAReleased();
            }
            if (recordedInputs[i].Contains('S') && !isSpressed)
            {
                isSpressed = true;
                virtualInputs.SendSPressed();
            }
            if (!recordedInputs[i].Contains('S') && isSpressed)
            {
                isSpressed = false;
                virtualInputs.SendSPressed();
                virtualInputs.SendSReleased();
            }
            if (recordedInputs[i].Contains('J') && !isUpPressed)
            {
                isUpPressed = true;
                virtualInputs.SendUpPressed();
            }
            if (!recordedInputs[i].Contains('J') && isUpPressed)
            {
                isUpPressed = false;
                virtualInputs.SendUpPressed();
                virtualInputs.SendUpReleased();
            }
            if (recordedInputs[i].Contains('G') && !isDownPressed)
            {
                isDownPressed = true;
                virtualInputs.SendDownPressed();
            }
            if (!recordedInputs[i].Contains('G') && isDownPressed)
            {
                isDownPressed = false;
                virtualInputs.SendDownPressed();
                virtualInputs.SendDownReleased();
            }

        }
    }
}
