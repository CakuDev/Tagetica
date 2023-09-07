using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private bool fullscreen = false;
    private int width = 1920;
    private int height = 1080;

    // resolution format: widthxheigh
    public void ChangeResolution(string resolution)
    {
        string[] dimensions = resolution.Split("x");
        width = int.Parse(dimensions[0]);
        height = int.Parse(dimensions[1]);
        Screen.SetResolution(width, height, fullscreen);
    }

    public void ChangeFullscreen(bool value)
    {
        fullscreen = value;
        Screen.SetResolution(width, height, fullscreen);
    }
}
