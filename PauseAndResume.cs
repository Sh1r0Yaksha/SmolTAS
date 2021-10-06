using SALT;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SmolTAS
{
    public class PauseAndResume
    {        
        public static bool LShiftPaused { get; set; }

        // Pause game method
        public static void PauseGame()
        {
            SALT.Timer.Pause(true);
            UserInputService.MouseVisible = false;
            SALT.Main.StopSave();
        }

        // Resume Game method
        public static void ResumeGame( float valueForTimeScale)
        {
            if (!MainScript.paused)
                Time.timeScale = valueForTimeScale;
        }
    }
}
