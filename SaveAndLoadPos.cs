using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace SmolTAS
{
    public class SaveAndLoadPos
    {
        public static bool isSaveAndLoadPosOn { get; set; } = true; // Boolean for toggling this mod

        private static Vector3 savedPlayerPosition = Vector3.zero; // Field for storing player position

        private static float savedLevelTime; // Field for saving the time of save

        // Method to save player position
        public static void SavePos(KeyCode keyPressed)
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
        public static void LoadPos(KeyCode keyPressed)
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
