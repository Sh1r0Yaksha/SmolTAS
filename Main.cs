using SALT;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace SmolTAS
{
    public class Main : ModEntryPoint
    {
        // Slow Mo toggle boolean
        public static bool isSlowMoOn = true;

        // Frame advance toggle boolean
        static bool isFrameAdvanceOn = true;

        // Save Position boolean
        static bool isSaveAndLoadPosOn = true;

        // Call SlowMo class
        SlowMo slowMo = new SlowMo(isSlowMoOn);

        // Call Pause and Resume Class
        PauseAndResume pauseAndResume = new PauseAndResume (0.005f);

        //Call Frame Advance class
        FrameAdvance frameAdvance = new FrameAdvance(isFrameAdvanceOn);

        // Call Save and load position mod
        SaveAndLoadPos saveAndLoadPos = new SaveAndLoadPos(isSaveAndLoadPosOn);

        // THE EXECUTING ASSEMBLY
        public static Assembly execAssembly;



        // Called before MainScript.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            // Gets the Assembly being executed
            execAssembly = Assembly.GetExecutingAssembly();
            HarmonyInstance.PatchAll(execAssembly);
        }


        // Called before MainScript.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            UserInputService.Instance.InputBegan += this.InputBegan;
            UserInputService.Instance.InputEnded += this.InputEnded;
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }

        // Called after any key is pressed
        public void InputBegan(UserInputService.InputObject inputObject, bool wasProcessed)
        {
            // Pausing and resuming keys start
            if (inputObject.keyCode == KeyCode.Q)
            {
                pauseAndResume.ResumeGame(slowMo.valueForTimeScale);
            }

            if (inputObject.keyCode == KeyCode.LeftShift)
            {
                pauseAndResume.PauseGame();
            }

            if (inputObject.keyCode == KeyCode.Escape)
            {
                pauseAndResume.PauseWhenEsc(KeyCode.Escape);
            }
            // Pausing and resuming keys end


            // Toggling mods start

            // Slow Mo mod toggle
            if (inputObject.keyCode == KeyCode.Alpha1)
            {
                if (isSlowMoOn)
                {
                    isSlowMoOn = false;
                    SALT.Console.Console.LogSuccess("Slow Motion mod is turned off");
                }
                else
                {
                    isSlowMoOn = true;
                    SALT.Console.Console.LogSuccess("Slow Motion mod is turned on");
                }
                slowMo.isSlowMoOn = isSlowMoOn;
            }

            //Frame Advance mod toggle
            if (inputObject.keyCode == KeyCode.Alpha2)
            {
                if (isFrameAdvanceOn)
                {
                    isFrameAdvanceOn = false;
                    SALT.Console.Console.Log("Frame Advance mod is turned off");
                }
                else
                {
                    isFrameAdvanceOn = true;
                    SALT.Console.Console.Log("Frame Advance mod is turned on");
                }
                frameAdvance.isFrameAdvanceOn = isFrameAdvanceOn;
            }

            //Save and load Position toggle
            if (inputObject.keyCode == KeyCode.Alpha3)
            {
                if (isSaveAndLoadPosOn)
                {
                    isSaveAndLoadPosOn = false;
                    SALT.Console.Console.Log("Frame Advance mod is turned off");
                }
                else
                {
                    isSaveAndLoadPosOn = true;
                    SALT.Console.Console.Log("Frame Advance mod is turned on");
                }
                saveAndLoadPos.isSaveAndLoadPosOn = isSaveAndLoadPosOn;
            }

            // Toggling mods end

            // Slow Mo class start
            slowMo.SetTimescaleValue(inputObject.keyCode);


            if (inputObject.keyCode == KeyCode.E && isSlowMoOn && SALT.Timer.IsPaused() && !MainScript.paused)
            {
                Time.timeScale = slowMo.valueForTimeScale;
                SALT.Console.Console.Log("E was pressed");
            }
            // Slow Mo class end

            // Frame Advance class start
            if (inputObject.keyCode == KeyCode.F)
            {
                frameAdvance.FrameAdvanceMethod();
            }
            // Frame Advance class end

            // Save and load position class start
            saveAndLoadPos.SavePos(inputObject.keyCode);
            saveAndLoadPos.LoadPos(inputObject.keyCode);
            //Save and load position class end
        }

        // Called after any key is released
        public void InputEnded(UserInputService.InputObject inputObject, bool wasProcessed)
        {
            // Slow Mo class start
            if (inputObject.keyCode == KeyCode.E && isSlowMoOn && !MainScript.paused)
            {
                pauseAndResume.PauseGame();
                SALT.Console.Console.Log("E was released");
            }
            // Slow Mo class end
        }
    }
}
