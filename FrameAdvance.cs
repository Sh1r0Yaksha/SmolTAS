using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;

namespace SmolTAS
{
    class FrameAdvance
    {
        public static bool isFrameAdvanceOn { get; set; } = true;

        private static int savedFrameCount; // field for saving the frame count at that moment

        private static System.Threading.Timer timerForFrameAdvance; // Creating timer for frame advance

        // The Method for advancing frames
        public static void FrameAdvanceMethod()
        {
            if (SALT.Timer.IsPaused() && isFrameAdvanceOn)
            {
                PauseAndResume.ResumeGame(1f);
                savedFrameCount = Time.frameCount;
                timerForFrameAdvance = new System.Threading.Timer(FrameTimer, null, 0, 1);
            }
        }

        // Method that is called every 1ms and resumes game until next frame or next ms is reached
        private static void FrameTimer(object o)
        {
            if (Time.frameCount - savedFrameCount < 1)
                PauseAndResume.ResumeGame(1f);
            else
            {
                PauseAndResume.PauseGame();
                timerForFrameAdvance.Dispose();
            }
        }
    }
}
