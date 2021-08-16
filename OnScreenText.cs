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
        public bool isCoordTextOn = true; // boolean to toggle coordinate and velocity text on or off

        public GameObject modEnabledText = null; // Create mods enabled/disabled text's gameobject

        public GameObject timeScaleValuesText = null; // Create Time Scale value text's gameobject

        public GameObject velText; // Create Velocity text's gameobject

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
                coordinateText.GetComponent<TextMeshProUGUI>().text = "Coordinates X: " + PlayerScript.player.transform.position.x + " Y: " +
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
                modsRT.SetPivotAndAnchors(new Vector2(1f, 1f));
                modsRT.localPosition = vRT.localPosition;
                modsRT.localScale = vRT.localScale;
                modsRT.anchoredPosition = vRT.anchoredPosition;
                modsRT.sizeDelta = vRT.sizeDelta;
                modsRT.offsetMin = vRT.offsetMin;
                modsRT.offsetMax = vRT.offsetMax;
                modsRT.anchoredPosition3D = vRT.anchoredPosition3D;
                modsRT.SetSiblingIndex(vRT.GetSiblingIndex() + 1);
                modsRT.localPosition = modsRT.localPosition.SetY((-vRT.localPosition.y) - 33.5f);
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

        // Create Velocity text as gameobject
        public void CreateVelocityText()
        {
            RectTransform velocity = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "velocity");
            if (velocity == null)
            {
                GameObject versionObject = UnityEngine.Object.FindObjectsOfType<RectTransform>().FirstOrDefault(tmp => tmp.gameObject.name == "Version").gameObject;
                GameObject velocityText = versionObject.CloneInstance();
                velocityText.name = "velocitytext";
                versionObject.transform.parent.gameObject.AddChild(velocityText, false);
                RectTransform vRT = versionObject.GetComponent<RectTransform>();
                RectTransform velRT = velocityText.GetComponent<RectTransform>().GetCopyOf(vRT);
                velRT.localPosition = vRT.localPosition;
                velRT.localScale = vRT.localScale;
                velRT.anchoredPosition = vRT.anchoredPosition;
                velRT.sizeDelta = vRT.sizeDelta;
                velRT.offsetMin = vRT.offsetMin;
                velRT.offsetMax = vRT.offsetMax;
                velRT.anchoredPosition3D = vRT.anchoredPosition3D;
                velRT.SetSiblingIndex(vRT.GetSiblingIndex() + 1);
                velRT.localPosition += new Vector3(0, 37.5f, 0);
                velocityText.GetComponent<TextMeshProUGUI>().text = " ";
                velText = velocityText;
            }
            else if (velText == null)
                velText = velocity.gameObject;
        }

        // Method to show velocity text on screen
        public void VelocityTextShow()
        {
            // Reflections magic
            PlayerScript dummyPlayer = SALT.Main.actualPlayer;
            Type typ = typeof(PlayerScript);
            FieldInfo type = typ.GetField("rb", System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);
            Rigidbody2D rigidBodyPlayer = (Rigidbody2D)type.GetValue(dummyPlayer);

            if (isCoordTextOn)
                velText.GetComponent<TextMeshProUGUI>().text = "Velocity X: " + rigidBodyPlayer.velocity.x + " Y: " +
                rigidBodyPlayer.velocity.y;

            else
                velText.GetComponent<TextMeshProUGUI>().text = " ";
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
