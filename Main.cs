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
        // THE EXECUTING ASSEMBLY
        public static Assembly execAssembly;
        public static int i = 0; // integer which runs the file's lines

        // Called before MainScript.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            // Gets the Assembly being executed
            execAssembly = Assembly.GetExecutingAssembly();
            HarmonyInstance.PatchAll(execAssembly);
            if (!File.Exists(SALT.FileSystem.GetMyPath() + "\\Inputs\\HCH.txt"))
                RegisterInputFromFile.CreateTextFile();
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
            OnScreenText.CreateCoordinateAndVelocityText();
            OnScreenText.CreateModsText();
            OnScreenText.CreateTimeScaleValueText();
            RegisterInputFromFile.ReadFiles(Level.MAIN_MENU);

            // Creating a gameobject that runs the FixedFrameRate class
            GameObject fixedFrameRateObject = new GameObject();
            FixedFrameRate fixedFrameRate = new FixedFrameRate();
            fixedFrameRateObject.AddComponent(fixedFrameRate);
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
            OnScreenText.TimeScaleValueTextShow();
            OnScreenText.CoordinateAndVelocityTextShow();     
        }

  
        // Called after every game physics frame (200fps)
        public override void FixedUpdate()
        {
            if (RegisterInputFromFile.recordedInputsList.Count > 2 && Time.timeScale != 0)
            {
                RegisterInputFromFile.DoInputs(i);
                i++;
            }

            if (!MainScript.paused && !PauseAndResume.LShiftPaused)
            {
                Time.timeScale = SlowMo.valueForTimeScale;
            }
        }

        // Called after a level is loaded
        void OnLevelLoaded()
        { 
            i = 0;
            RegisterInputFromFile.ResetInputs();
            RegisterInputFromFile.ReadFiles(Levels.CurrentLevel);
            GC.Collect();

            // Creating a gameobject that runs the FixedFrameRate class
            GameObject fixedFrameRateObject = new GameObject();
            FixedFrameRate fixedFrameRate = new FixedFrameRate();
            fixedFrameRateObject.AddComponent(fixedFrameRate);  

            if (Levels.isRedHeart() || Levels.isInascapableMadness() || Levels.isMoguMogu() || Levels.isPekoland())
            {
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().color = Color.black;
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineColor = Color.white;
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().color = Color.black;
                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineColor = Color.white;
                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().color = Color.black;
                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineColor = Color.white;
                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
            }
            else
            {
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().color = Color.white;
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
                OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().color = Color.white;
                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
                OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().color = Color.white;
                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
                OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
            }
        }

        // Called after the main hub is loaded
        void OnMainMenuLoaded()
        {
            i = 0;
            RegisterInputFromFile.ResetInputs();
            RegisterInputFromFile.ReadFiles(0);
            GC.Collect();

            // Creating a gameobject that runs the FixedFrameRate class
            GameObject fixedFrameRateObject = new GameObject();
            FixedFrameRate fixedFrameRate = new FixedFrameRate();
            fixedFrameRateObject.AddComponent(fixedFrameRate);

            OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().color = Color.white;
            OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            OnScreenText.timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

            OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().color = Color.white;
            OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            OnScreenText.coordinateText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;

            OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().color = Color.white;
            OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
        }


        // Called after any key is pressed
        public void InputBegan(UserInputService.InputObject inputObject, bool wasProcessed)
        {

            // Pausing and resuming keys start
            if (inputObject.keyCode == KeyCode.Q)
            {
                PauseAndResume.ResumeGame(SlowMo.valueForTimeScale);
                PauseAndResume.LShiftPaused = false;
            }

            if (inputObject.keyCode == KeyCode.LeftShift)
            {
                PauseAndResume.PauseGame();
                PauseAndResume.LShiftPaused = true;
            }
            
            // Pausing and resuming keys end

            // toggling mods start

            // Slow Mo mod toggle
            if (inputObject.keyCode == KeyCode.Alpha1)
            {
                if (SlowMo.isSlowMoOn)
                {
                    SlowMo.isSlowMoOn = false;
                    OnScreenText.isTimeScaleTextOn = false;
                }
                else
                {
                    SlowMo.isSlowMoOn = true;
                    OnScreenText.isTimeScaleTextOn = true;
                }
            }

            //Frame Advance mod toggle
            if (inputObject.keyCode == KeyCode.Alpha2)
                FrameAdvance.isFrameAdvanceOn = !FrameAdvance.isFrameAdvanceOn;

            //Save and load Position toggle
            if (inputObject.keyCode == KeyCode.Alpha3)
                SaveAndLoadPos.isSaveAndLoadPosOn = !SaveAndLoadPos.isSaveAndLoadPosOn;

            // Coordinates text toggle
            if (inputObject.keyCode == KeyCode.BackQuote)
            {
                if (OnScreenText.isCoordTextOn)
                {
                    OnScreenText.isCoordTextOn = false;
                    OnScreenText.isTimeScaleTextOn = false;
                }
                else
                {
                    OnScreenText.isCoordTextOn = true;
                    OnScreenText.isTimeScaleTextOn = true;
                }
            }
            // Toggling mods end

            // Slow Mo class start
            SlowMo.SetTimescaleValue(inputObject.keyCode);
            if (inputObject.keyCode == KeyCode.E && SlowMo.isSlowMoOn && SALT.Timer.IsPaused() && !MainScript.paused)
                Time.timeScale = SlowMo.valueForTimeScale;
            // Slow Mo class end

            // Frame Advance class start
            if (inputObject.keyCode == KeyCode.F)
                FrameAdvance.FrameAdvanceMethod();
            // Frame Advance class end

            // Save and load position class start
            SaveAndLoadPos.SavePos(inputObject.keyCode);
            SaveAndLoadPos.LoadPos(inputObject.keyCode);
            //Save and load position class end          
        }

        // Called after any key is released
        public void InputEnded(UserInputService.InputObject inputObject, bool wasProcessed)
        {
            // Slow Mo class start
            if (inputObject.keyCode == KeyCode.E && SlowMo.isSlowMoOn && !MainScript.paused)
                PauseAndResume.PauseGame();
            // Slow Mo class end
        }

        // Prints Mods Enabled or Disabled Text
        public void ModstoggleText()
        {
            OnScreenText.modEnabledText.GetComponent<TextMeshProUGUI>().text = "Slow-Mo: " + OnScreenText.EnabledDisabledText(SlowMo.isSlowMoOn) + 
                "\nFrame Advance: " + OnScreenText.EnabledDisabledText(FrameAdvance.isFrameAdvanceOn) +
              "\nSave And load: " + OnScreenText.EnabledDisabledText(SaveAndLoadPos.isSaveAndLoadPosOn);
        }
    }

}
