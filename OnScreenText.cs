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
    class OnScreenText
    {
        public GameObject coordinateText = null; // Create coordinate text's gameobject
        public bool isCoordTextOn = true; // boolean to toggle coordinate text on or off

        public GameObject modEnabledText = null; // Create mods enabled/disabled text's gameobject

        public GameObject timeScaleValuesText = null; // Create Time Scale value text's gameobject
        public bool isTimeScaleTextOn = true; // boolean to toggle time scale text on or off

        public OnScreenText() { } // Constructor for this class

        // Method for creating coordinates text as a game object
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
                coordinateText = coordinates.gameObject;
        }

        // Method to show coordinates on screen
        public void CoordinatesTextShow()
        {
            if (isCoordTextOn)
                coordinateText.GetComponent<TextMeshProUGUI>().text = "X: " + PlayerScript.player.transform.position.x + " Y: " +
                PlayerScript.player.transform.position.y;

            else
                coordinateText.GetComponent<TextMeshProUGUI>().text = " ";
        }

        // Method for creating mods enabled text as a game object
        public void CreateModsText()
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
                modEnabledText = modsText.gameObject;
        }

        // Method for Time scale value text as a game object
        public void CreateTimeScaleValueText()
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
                timeScaleRT.localPosition = -vRT.localPosition;
                timeScaleRT.localScale = vRT.localScale;
                timeScaleRT.anchoredPosition = -vRT.anchoredPosition;
                timeScaleRT.sizeDelta = vRT.sizeDelta;
                timeScaleRT.offsetMin = vRT.offsetMin;
                timeScaleRT.offsetMax = vRT.offsetMax;
                timeScaleRT.anchoredPosition3D = vRT.anchoredPosition3D;
                timeScaleRT.SetSiblingIndex(vRT.GetSiblingIndex() + 1);
                timeScaleRT.localPosition += new Vector3(-680f, 15f, 0);               
                timeScaleValueText.GetComponent<TextMeshProUGUI>().text = " ";
                timeScaleValuesText = timeScaleValueText;
            }
            else if (timeScaleValuesText == null)
                timeScaleValuesText = timeScaleText.gameObject;
        }

        // Prints Enabled for True and Disabled for False
        public string EnabledDisabledText(bool temp)
        {
            if (temp)
                return "Enabled";
            else
                return "Disabled";
        }
    }
}
