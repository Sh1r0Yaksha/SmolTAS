using SALT;
using HarmonyLib;
using System;
using UnityEngine;

namespace SmolTAS
{
    public class SlowMo
    {
        public static bool isSlowMoOn { get; set; } = true; // Boolean for toggling this mod

        public static float valueForTimeScale { get; set; } = 1f; // Property for timescale value

        private static float deltaTime = Time.deltaTime; // Field for storing delta time of the moment

        // Method that sets the value of timescale
        public static void SetTimescaleValue(KeyCode pressedKey)
        {
            if (isSlowMoOn)
            {
                if (pressedKey == KeyCode.F2)
                    valueForTimeScale = deltaTime;

                if (pressedKey == KeyCode.F3)
                    valueForTimeScale = 0.1f;

                if (pressedKey == KeyCode.F4)
                    valueForTimeScale = 1f;

                if (pressedKey == KeyCode.F5)
                {
                    valueForTimeScale -= 0.1f;
                    if (valueForTimeScale < 0f)
                        valueForTimeScale = 1f;
                }

                if (pressedKey == KeyCode.F6)
                    valueForTimeScale += 0.1f;

                if (pressedKey == KeyCode.F7)
                    valueForTimeScale = 10f;
            }
        }
    }
}
