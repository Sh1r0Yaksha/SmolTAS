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
    public class OnScreenText
    {
        public static GameObject coordinateText = null; // Create coordinate text's gameobject
        public static bool isCoordTextOn { get; set; } = true; // boolean to toggle coordinate and velocity text on or off

        public static GameObject modEnabledText = null; // Create mods enabled/disabled text's gameobject

        public static GameObject timeScaleValuesText = null; // Create Time Scale value text's gameobject
        public static bool isTimeScaleTextOn { get; set; } = true; // boolean to toggle time scale text on or off


        public OnScreenText() { } // Constructor for this class

        // Method for creating coordinates text as a game object
        public static void CreateCoordinateAndVelocityText()
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
                coordinateText = coordinates.gameObject;

            coordinateText.GetComponent<TextMeshProUGUI>().color = Color.white;
            coordinateText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            coordinateText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
        }

        // Method for creating mods enabled text as a game object
        public static void CreateModsText()
        {
            RectTransform modsText = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "modsenabledtext");
            if (modsText == null)
            {
                GameObject versionObject = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "Version").gameObject;
                GameObject modsEnabledText = versionObject.CloneInstance();
                modsEnabledText.name = "modsenabledtext";
                versionObject.transform.parent.gameObject.AddChild(modsEnabledText, false);
                RectTransform vRT = versionObject.GetComponent<RectTransform>();
                RectTransform modsRT = modsEnabledText.GetComponent<RectTransform>().GetCopyOf(vRT);
                modsRT.SetPivotAndAnchors(new Vector2(1f, 1f));
                modsRT.localPosition = vRT.localPosition;
                modsRT.localScale = vRT.localScale;
                modsRT.anchoredPosition = vRT.anchoredPosition;
                modsRT.sizeDelta = vRT.sizeDelta;
                modsRT.offsetMin = vRT.offsetMin;
                modsRT.offsetMax = vRT.offsetMax;
                modsRT.anchoredPosition3D = vRT.anchoredPosition3D;
                modsRT.SetSiblingIndex(vRT.GetSiblingIndex() + 2);
                modsRT.localPosition = modsRT.localPosition.SetY((-vRT.localPosition.y) - 10f);
                modsEnabledText.GetComponent<TextMeshProUGUI>().text = " ";
                modEnabledText = modsEnabledText;
            }
            else if (modEnabledText == null)
                modEnabledText = modsText.gameObject;

            modEnabledText.GetComponent<TextMeshProUGUI>().color = Color.white;
            modEnabledText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            modEnabledText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
        }

        // Method for Time scale value text as a game object
        public static void CreateTimeScaleValueText()
        {
            RectTransform timeScaleText = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "timescaletext");
            if (timeScaleText == null)
            {
                GameObject versionObject = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "Version").gameObject;
                GameObject timeScaleValueText = versionObject.CloneInstance();
                timeScaleValueText.name = "timescaletext";
                versionObject.transform.parent.gameObject.AddChild(timeScaleValueText, false);
                RectTransform vRT = versionObject.GetComponent<RectTransform>();
                RectTransform timeScaleRT = timeScaleValueText.GetComponent<RectTransform>().GetCopyOf(vRT);
                timeScaleRT.SetPivotAndAnchors(new Vector2(1.95f, 4f));
                timeScaleRT.localPosition = vRT.localPosition;
                timeScaleRT.localScale = vRT.localScale;
                timeScaleRT.anchoredPosition = vRT.anchoredPosition;
                timeScaleRT.sizeDelta = vRT.sizeDelta;
                timeScaleRT.offsetMin = vRT.offsetMin;
                timeScaleRT.offsetMax = vRT.offsetMax;
                timeScaleRT.anchoredPosition3D = vRT.anchoredPosition3D;
                timeScaleRT.SetSiblingIndex(vRT.GetSiblingIndex() + 3);
                timeScaleRT.localPosition = timeScaleRT.localPosition.SetX(0f);
                timeScaleRT.localPosition = timeScaleRT.localPosition.SetY(0f);
                timeScaleValueText.GetComponent<TextMeshProUGUI>().text = " ";
                timeScaleValuesText = timeScaleValueText;
            }
            else if (timeScaleValuesText == null)
                timeScaleValuesText = timeScaleText.gameObject;

            timeScaleValuesText.GetComponent<TextMeshProUGUI>().color = Color.white;
            timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineColor = Color.black;
            timeScaleValuesText.GetComponent<TextMeshProUGUI>().outlineWidth = 0.2f;
            timeScaleValuesText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
        }        

        // Method to show velocity text on screen
        public static void CoordinateAndVelocityTextShow()
        {
            // Reflections magic
            PlayerScript dummyPlayer = SALT.Main.actualPlayer;
            Type typ = typeof(PlayerScript);
            FieldInfo type = typ.GetField("rb", System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);
            Rigidbody2D rigidBodyPlayer = (Rigidbody2D)type.GetValue(dummyPlayer);

            if (isCoordTextOn)
            {
                coordinateText.GetComponent<TextMeshProUGUI>().text = "Velocity X: " + rigidBodyPlayer.velocity.x + " Y: " + rigidBodyPlayer.velocity.y +
                    "\nCoordinates X: " + PlayerScript.player.transform.position.x + " Y: " + PlayerScript.player.transform.position.y;
            }

            else
                coordinateText.GetComponent<TextMeshProUGUI>().text = " ";
        }

        // Prints Time Scale Value text
        public static void TimeScaleValueTextShow()
        {
            if (isTimeScaleTextOn)
            {
                timeScaleValuesText.GetComponent<TextMeshProUGUI>().text = "Current frame: " + Time.frameCount +
                    "\nline on text file: " + SmolTAS.Main.i +
                    "\nTimescale value: " + SlowMo.valueForTimeScale + "\n";
                if (RegisterInputFromFile.isWpressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "W";
                if (RegisterInputFromFile.isApressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "A";
                if (RegisterInputFromFile.isSpressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "S";
                if (RegisterInputFromFile.isDpressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "D";
                if (RegisterInputFromFile.isUpPressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "↑";
                if (RegisterInputFromFile.isDownPressed)
                    timeScaleValuesText.GetComponent<TextMeshProUGUI>().text += "↓";
            }
            else
                timeScaleValuesText.GetComponent<TextMeshProUGUI>().text = " ";
        }

        // Prints Enabled for True and Disabled for False
        public static string EnabledDisabledText(bool temp)
        {
            if (temp)
                return "Enabled";
            else
                return "Disabled";
        }
    }
}
