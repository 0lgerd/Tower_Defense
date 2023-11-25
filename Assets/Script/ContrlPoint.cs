using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        try
        {
            // Initialize an array of child transforms
            points = new Transform[transform.childCount];

            // Populate the array with child transforms
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = transform.GetChild(i);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Awake(): {ex.Message}");
        }
    }
}
