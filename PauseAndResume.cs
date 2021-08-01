using SALT;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SmolTAS
{
    class PauseAndResume
    {
        // For toggling this mod
        static bool isSlowMoOn = Main.isSlowMoOn;

        // To set F2 value to delta time
        public float deltaTimeValue;

        public PauseAndResume(float deltaTimeValue)
        {
            this.deltaTimeValue = deltaTimeValue;
        }


        // Pause game method
        public void PauseGame()
        {
            if (Time.deltaTime > 0.0001f)
            {
                deltaTimeValue = Time.deltaTime;
            }
            SALT.Timer.Pause(true);
            UserInputService.MouseVisible = false;
            SALT.Main.StopSave();
        }

        // Resume Game method
        public void ResumeGame( float valueForTimeScale)
        {
            if (!MainScript.paused)
            {
                if (isSlowMoOn)
                {
                    Time.timeScale = valueForTimeScale;
                }
                else
                {
                    SALT.Timer.Unpause(true);
                }
            }
        }

        // When pause menu is toggled, game remains paused
        public void PauseWhenEsc(KeyCode escPressed)
        {
            if (escPressed == KeyCode.Escape && MainScript.pauseToggled)
            {
                PauseGame();
            }
        }
    }
}
