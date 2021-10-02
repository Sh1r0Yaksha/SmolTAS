using SALT;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;
using System.Threading;
using System.Linq;
using SALT.Extensions;
using TMPro;
using System.IO;

namespace SmolTAS
{
    public class Main : ModEntryPoint
    {
        SlowMo slowMo = new SlowMo(); // Call SlowMo class

        PauseAndResume pauseAndResume = new PauseAndResume(); // Call Pause and Resume Class

        FrameAdvance frameAdvance = new FrameAdvance(); //Call Frame Advance class

        SaveAndLoadPos saveAndLoadPos = new SaveAndLoadPos(); // Call Save and load position mod

        OnScreenText onScreenText = new OnScreenText(); // Call OnScreenText Class

        RegisterInputFromFile registerInput = new RegisterInputFromFile(); // Call RegisterInputFromFile Class 

        int i = 0; // integer which runs the file's lines

        // THE EXECUTING ASSEMBLY
        public static Assembly execAssembly;
        

        // Called before MainScript.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            // Gets the Assembly being executed
            execAssembly = Assembly.GetExecutingAssembly();
            HarmonyInstance.PatchAll(execAssembly);
            if (!File.Exists(SALT.FileSystem.GetMyPath() + "\\Inputs\\HCH.txt"))
                registerInput.CreateTextFile();
        }



        // Called before MainScript.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            UserInputService.Instance.InputBegan += this.InputBegan;
            UserInputService.Instance.InputEnded += this.InputEnded;
            SALT.Callbacks.OnLevelLoaded += this.OnLevelLoaded;
            SALT.Callbacks.OnMainMenuLoaded += this.OnMainMenuLoaded;

            // Calling coordinates text and mod text method to create the game object
            onScreenText.CreateCoordinateAndVelocityText();
            onScreenText.CreateModsText();
            onScreenText.CreateTimeScaleValueText();
            registerInput.ReadFiles(Level.MAIN_MENU);

        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }
        
        // Called after every game frame
        public override void Update()
        {
            ModstoggleText();
            TimeScaleValuePrint();
            onScreenText.CoordinateAndVelocityTextShow();       
        }

  
        // Called after every game physics frame (200fps)
        public override void FixedUpdate()
        {
            if (RegisterInputFromFile.recordedInputsList.Count > 2)
            {
                registerInput.DoInputs(i);
                i++;
            }
        }

        // Called after a level is loaded
        void OnLevelLoaded()
        { 
            i = 0;
            registerInput.ResetInputs();
            registerInput.ReadFiles(Levels.CurrentLevel);
            SALT.Main.StopSave();
        }

        // Called after the main hub is loaded
        void OnMainMenuLoaded()
        {
            i = 0;
            registerInput.ResetInputs();
            registerInput.ReadFiles(0);
        }


        // Called after any key is pressed
        public void InputBegan(UserInputService.InputObject inputObject, bool wasProcessed)
        {

            // Pausing and resuming keys start
            if (inputObject.keyCode == KeyCode.Q)
                pauseAndResume.ResumeGame(slowMo.valueForTimeScale);

            if (inputObject.keyCode == KeyCode.LeftShift)
                pauseAndResume.PauseGame();
            // Pausing and resuming keys end

            // toggling mods start

            // Slow Mo mod toggle
            if (inputObject.keyCode == KeyCode.Alpha1)
            {
                if (slowMo.isSlowMoOn)
                {
                    slowMo.isSlowMoOn = false;
                    onScreenText.isTimeScaleTextOn = false;
                }
                else
                {
                    slowMo.isSlowMoOn = true;
                    onScreenText.isTimeScaleTextOn = true;
                }
            }

            //Frame Advance mod toggle
            if (inputObject.keyCode == KeyCode.Alpha2)
                frameAdvance.isFrameAdvanceOn = !frameAdvance.isFrameAdvanceOn;

            //Save and load Position toggle
            if (inputObject.keyCode == KeyCode.Alpha3)
                saveAndLoadPos.isSaveAndLoadPosOn = !saveAndLoadPos.isSaveAndLoadPosOn;

            // Coordinates text toggle
            if (inputObject.keyCode == KeyCode.BackQuote)
            {
                if (onScreenText.isCoordTextOn)
                {
                    onScreenText.isCoordTextOn = false;
                    onScreenText.isTimeScaleTextOn = false;
                }
                else
                {
                    onScreenText.isCoordTextOn = true;
                    onScreenText.isTimeScaleTextOn = true;
                }
            }
            // Toggling mods end

            // Slow Mo class start
            slowMo.SetTimescaleValue(inputObject.keyCode);
            if (inputObject.keyCode == KeyCode.E && slowMo.isSlowMoOn && SALT.Timer.IsPaused() && !MainScript.paused)
                Time.timeScale = slowMo.valueForTimeScale;
            // Slow Mo class end

            // Frame Advance class start
            if (inputObject.keyCode == KeyCode.F)
                frameAdvance.FrameAdvanceMethod();
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
            if (inputObject.keyCode == KeyCode.E && slowMo.isSlowMoOn && !MainScript.paused)
                pauseAndResume.PauseGame();
            // Slow Mo class end
        }

        // Prints Mods Enabled or Disabled Text
        public void ModstoggleText()
        {
            onScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().text = "Slow-Mo: " + onScreenText.EnabledDisabledText(slowMo.isSlowMoOn) + 
                "\nFrame Advance: " + onScreenText.EnabledDisabledText(frameAdvance.isFrameAdvanceOn) +
              "\nSave And load: " + onScreenText.EnabledDisabledText(saveAndLoadPos.isSaveAndLoadPosOn);
        }

        // Prints Time Scale Value text
        public void TimeScaleValuePrint()
        {
            if (onScreenText.isTimeScaleTextOn)
                onScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().text ="Current frame: "+ Time.frameCount + 
                    "\nline on text file: " + i +
                    "\nTimescale value: " + slowMo.valueForTimeScale;
            else
                onScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().text = " ";
        }
    }

}
