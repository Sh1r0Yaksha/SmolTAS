using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;

namespace SmolTAS
{
    class SaveAndLoadPos
    {
        public bool isSaveAndLoadPosOn = true; // Boolean for toggling this mod

        private Vector3 savedPlayerPosition = Vector3.zero; // Field for storing player position

        private float savedLevelTime; // Field for saving the time of save

        // Constructor for this class
        public SaveAndLoadPos() { }

        // Method to save player position
        public void SavePos(KeyCode keyPressed)
        {
            if (keyPressed == KeyCode.F10 && isSaveAndLoadPosOn)
            {
                savedPlayerPosition = PlayerScript.player.transform.position;
                if (!Levels.isMainMenu())
                    savedLevelTime = SALT.Main.mainScript.levelTime;

                SALT.Console.ConsoleWindow.print("Saved Player's position!");
            }
        }

        // Method to load player position along with camera position
        public void LoadPos(KeyCode keyPressed)
        {
            if (keyPressed == KeyCode.F11 && isSaveAndLoadPosOn)
            {
                PlayerScript.player.transform.position = savedPlayerPosition;
                if (!Levels.isMainMenu())
                    SALT.Main.mainScript.levelTime = savedLevelTime;

                CamScript.camScript.SnapToPos();
                SALT.Main.StopSave();
                SALT.Console.ConsoleWindow.print("Loaded player's position");
            }
        }
    }
}
