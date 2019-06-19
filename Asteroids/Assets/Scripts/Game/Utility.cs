using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    // calculates and returns amera bounds with gien padding (default to 1f)
    public static Bounds GetBounds(this Camera cam, float padding = 1f)
    {
        // Define camera dimensions float
        float camheight, camWidth;
        // get position of camera
        Vector3 camPos = cam.transform.position;
        // Calculate height and width of camera
        camheight = 2f * cam.orthographicSize;
        camWidth = camheight * cam.aspect;
        // Apply padding
        camheight += padding;
        camWidth += padding;
        // Create a camera bounds from above information
        return new Bounds(camPos, new Vector3(camWidth, camheight, 100));

    }
	
}
