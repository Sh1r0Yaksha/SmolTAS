using System;
using System.Threading;
using SALT;
using HarmonyLib;
using UnityEngine;

namespace SmolTAS
{
    class FrameAdvance
    {
        // Boolean for toggling this mod
        public bool isFrameAdvanceOn { get; set; }

        // Calling Pause and resume class
        PauseAndResume pauseAndResume = new PauseAndResume(Time.deltaTime);

        // field for saving the frame count at that moment
        private int savedFrameCount;

        // Creating timer
        System.Threading.Timer timer;

        // Constructor for this class
        public FrameAdvance(bool isFrameAdvanceOn)
        {
            this.isFrameAdvanceOn = isFrameAdvanceOn;
        }

        // The Method for advancing frames
        public void FrameAdvanceMethod()
        {
            if (SALT.Timer.IsPaused() && isFrameAdvanceOn)
            {
                SALT.Timer.Unpause(true);
                savedFrameCount = Time.frameCount;
                timer = new System.Threading.Timer(FrameTimer, null, 0, 1);
            }
        }

        // Method that is called every 1ms and resumes game until next frame is reached
        private void FrameTimer(object o)
        {
            if (Time.frameCount - savedFrameCount < 1)
            {
                pauseAndResume.ResumeGame(1f);
            }
            else
            {
                pauseAndResume.PauseGame();
                timer.Dispose();
            }
        }
    }
}
