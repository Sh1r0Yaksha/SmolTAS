using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;

namespace SmolTAS
{
    class FrameAdvance
    {
        public bool isFrameAdvanceOn = true; // Boolean for toggling this mod

        PauseAndResume pauseAndResume = new PauseAndResume(); // Calling Pause and resume class

        private int savedFrameCount; // field for saving the frame count at that moment

        System.Threading.Timer timerForFrameAdvance; // Creating timer for frame advance

        // Constructor for this class
        public FrameAdvance() { }

        // The Method for advancing frames
        public void FrameAdvanceMethod()
        {
            if (SALT.Timer.IsPaused() && isFrameAdvanceOn)
            {
                pauseAndResume.ResumeGame(1f);
                savedFrameCount = Time.frameCount;
                timerForFrameAdvance = new System.Threading.Timer(FrameTimer, null, 0, 1);
            }
        }

        // Method that is called every 1ms and resumes game until next frame or next ms is reached
        private void FrameTimer(object o)
        {
            if (Time.frameCount - savedFrameCount < 1)
                pauseAndResume.ResumeGame(1f);
            else
            {
                pauseAndResume.PauseGame();
                timerForFrameAdvance.Dispose();
            }

        }
    }
}
