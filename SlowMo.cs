using SALT;
using HarmonyLib;
using System;
using UnityEngine;

namespace SmolTAS
{
    class SlowMo
    {
        public bool isSlowMoOn = true; // Boolean for toggling this mod
        
        public float valueForTimeScale = 1f; // Field for timescale value
       
        public float deltaTime = Time.deltaTime; // Field for storing delta time of the moment

        // Constructor for this class
        public SlowMo() { }

        // Method that sets the value of timescale
        public void SetTimescaleValue(KeyCode pressedKey)
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
            }
        }
    }
}
