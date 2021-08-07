using SALT;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;
using System.Threading;
using System.Linq;
using SALT.Extensions;
using TMPro;

namespace SmolTAS
{
    public class Main : ModEntryPoint
    {        
        public static bool isSlowMoOn = true; // Slow Mo toggle boolean
       
        static bool isFrameAdvanceOn = true; // Frame advance toggle boolean 
      
        static bool isSaveAndLoadPosOn = true; // Save Position toggle boolean

        private bool isCoordTextOn = true; // Coordinates text toggle boolean

        SlowMo slowMo = new SlowMo(isSlowMoOn); // Call SlowMo class
        
        PauseAndResume pauseAndResume = new PauseAndResume (0.005f); // Call Pause and Resume Class
        
        FrameAdvance frameAdvance = new FrameAdvance(isFrameAdvanceOn); //Call Frame Advance class
        
        SaveAndLoadPos saveAndLoadPos = new SaveAndLoadPos(isSaveAndLoadPosOn); // Call Save and load position mod

        public GameObject coordinateText = null; // Create coordinates text

        public GameObject modEnabledText = null; // Create text which tell mods are enabled or not


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

            // Calling coordinates text and mod text method to create the game object
            CreateCoordinateText();
            CreateModsText();
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }

        // Called after every game frame
        public override void Update()
        {
            toggleCoordinatesText();
            modstoggleText();
            base.Update();
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

            // Coordinates text toggle
            if (inputObject.keyCode == KeyCode.BackQuote)
            {
                SALT.Console.Console.Log("Tilde pressed");
                if (isCoordTextOn)
                {
                    isCoordTextOn = false;
                }
                else
                {
                    isCoordTextOn = true;
                }
            }

            // Toggling mods end

            // Slow Mo class start
            slowMo.SetTimescaleValue(inputObject.keyCode);


            if (inputObject.keyCode == KeyCode.E && isSlowMoOn && SALT.Timer.IsPaused() && !MainScript.paused)
            {
                Time.timeScale = slowMo.valueForTimeScale;
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
            }
            // Slow Mo class end
        }

        // Coordinates text Method
        public void CreateCoordinateText()
        {
            RectTransform coordinates = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "coordinates");
            if (coordinates == null)
            {
                GameObject versionObject = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "Version").gameObject;
                GameObject coordinatesText = versionObject.CloneInstance();
                coordinatesText.name = "coordinatestext";
                versionObject.transform.parent.gameObject.AddChild(coordinatesText, false);
                RectTransform vRT = versionObject.GetComponent<RectTransform>();
                RectTransform coorRT = coordinatesText.GetComponent<RectTransform>().GetCopyOf(vRT);
                coorRT.localPosition = vRT.localPosition;
                coorRT.localScale = vRT.localScale;
                coorRT.anchoredPosition = vRT.anchoredPosition;
                coorRT.sizeDelta = vRT.sizeDelta;
                coorRT.offsetMin = vRT.offsetMin;
                coorRT.offsetMax = vRT.offsetMax;
                coorRT.anchoredPosition3D = vRT.anchoredPosition3D;
                coorRT.SetSiblingIndex(vRT.GetSiblingIndex() + 1);
                coorRT.localPosition += new Vector3(0, 25f, 0);
                coordinatesText.GetComponent<TextMeshProUGUI>().text = " ";
                coordinateText = coordinatesText;
            }
            else if (coordinateText == null)
            {
                coordinateText = coordinates.gameObject;

            }
        }

        // Coordinates text toggle
        void toggleCoordinatesText()
        {
            // Seting the corrdinates text to update every frame
            if (isCoordTextOn)
            {
                coordinateText.GetComponent<TextMeshProUGUI>().text = "X: " + PlayerScript.player.transform.position.x + " Y: " +
                PlayerScript.player.transform.position.y;
            }
            else
            {
                coordinateText.GetComponent<TextMeshProUGUI>().text = " ";
            }
        }

        // Mods text Method
        public void CreateModsText()
        {
            RectTransform modsText = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "coordinates");
            if (modsText == null)
            {
                GameObject versionObject = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "Version").gameObject;
                GameObject modsEnabledText = versionObject.CloneInstance();
                modsEnabledText.name = "modsenabledtext";
                versionObject.transform.parent.gameObject.AddChild(modsEnabledText, false);
                RectTransform vRT = versionObject.GetComponent<RectTransform>();
                RectTransform modsRT = modsEnabledText.GetComponent<RectTransform>().GetCopyOf(vRT);
                modsRT.localPosition = vRT.localPosition;
                modsRT.localScale = vRT.localScale;
                modsRT.anchoredPosition = vRT.anchoredPosition;
                modsRT.sizeDelta = vRT.sizeDelta;
                modsRT.offsetMin = vRT.offsetMin;
                modsRT.offsetMax = vRT.offsetMax;
                modsRT.anchoredPosition3D = vRT.anchoredPosition3D;
                modsRT.SetSiblingIndex(vRT.GetSiblingIndex() + 1);
                modsRT.localPosition += new Vector3(0, 345f, 0);
                modsEnabledText.GetComponent<TextMeshProUGUI>().text = " ";
                modEnabledText = modsEnabledText;
            }
            else if (modEnabledText == null)
            {
                modEnabledText = modsText.gameObject;

            }
        }

        // Prints Mods Enabled or Disabled Text
        void modstoggleText()
        {
            modEnabledText.GetComponent<TextMeshProUGUI>().text = "Slow-Mo: " + EnabledDisabledText(isSlowMoOn) +
                "\nFrame Advance: " + EnabledDisabledText(isFrameAdvanceOn) + "\nSave And load: " + EnabledDisabledText(isSaveAndLoadPosOn);
        }

        // Prints Enabled for True and Disabled for False
        string EnabledDisabledText(bool temp)
        {
            if (temp)
            {
                return "Enabled";
            }
            else
            {
                return "Disabled";
            }
        }
    }
}
