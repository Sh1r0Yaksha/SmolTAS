using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;

namespace SmolTAS
{
    class SaveAndLoadPos
    {
        // Boolean for toggling this mod
        public bool isSaveAndLoadPosOn;

        // Field for storing player position
        private Vector3 savedPlayerPosition;

        // Constructor for this class
        public SaveAndLoadPos(bool isSaveAndLoadPosOn)
        {
            this.isSaveAndLoadPosOn = isSaveAndLoadPosOn;
        }

        // Method to save player position
        public void SavePos(KeyCode keyPressed)
        {
            if (keyPressed == KeyCode.F10 && isSaveAndLoadPosOn)
            {
                savedPlayerPosition = PlayerScript.player.transform.position;
                SALT.Console.ConsoleWindow.print("Saved Player's position!");
            }
        }

        // Method to load player position along with camera position
        public void LoadPos(KeyCode keyPressed)
        {
            if (keyPressed == KeyCode.F11 && isSaveAndLoadPosOn)
            {
                PlayerScript.player.transform.position = savedPlayerPosition;
                SALT.Console.ConsoleWindow.print("Loaded player's position");
                CamScript.camScript.SnapToPos();
                SALT.Main.StopSave();
            }
        }
    }
}
