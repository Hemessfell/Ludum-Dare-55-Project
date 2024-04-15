using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    private static Camera mainCamera;

    public static Camera MainCamera()
    {
        if (!mainCamera)
            mainCamera = Camera.main;

        return mainCamera;
    }

    public static Vector3 WorldMousePosition()
    {
        return MainCamera().ScreenToWorldPoint(Input.mousePosition);
    }

    public static float Map(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp)
    {
        float newValue = (value - originalMin) / (originalMax - originalMin) * (newMax - newMin) + newMin;
        if (clamp)
            newValue = Mathf.Clamp(newValue, newMin, newMax);
        return newValue;
    }

    public static void DeleteAllChildren(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Object.Destroy(parent.GetChild(i).gameObject);
        }
    }

    public static void DisableAllChildren(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public static Dictionary<float, WaitForSeconds> WaitForSecondsNonAlloc = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWait(float seconds)
    {
        bool exists = WaitForSecondsNonAlloc.TryGetValue(seconds, out var wait);

        if (exists)
            return wait;

        WaitForSeconds temp = new WaitForSeconds(seconds);
        WaitForSecondsNonAlloc.Add(seconds, temp);

        return temp;
    }
}
