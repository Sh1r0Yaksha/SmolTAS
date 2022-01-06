using System.Collections;
using System.Threading;
using UnityEngine;

public class FixedFrameRate : MonoBehaviour
{
    //public float Rate { get; set; } = 200.0f;
    public static float Rate { get; set; } = 144.0f;
    float currentFrameTime;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 9999;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine("WaitForNextFrame");
        Time.captureDeltaTime = 1.0f / Rate;
    }

    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / Rate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup;

        }
    }
}