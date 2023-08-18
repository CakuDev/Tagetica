using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionBehaviour : MonoBehaviour
{

    private int lastWidth;
    private int lastHeight;

    [SerializeField] private bool isFullscreen = false;

    // Start is called before the first frame update
    void Start()
    {
        lastWidth = Screen.width;
        lastHeight = Screen.height;
        Debug.Log($"{lastWidth}x{lastHeight}");
    }

    // Update is called once per frame
    void Update()
    {

        if (lastWidth != Screen.width)
        {
            Screen.SetResolution(Screen.width, (int) (Screen.width * (9f / 16f)), isFullscreen);
        }
        else if (lastHeight != Screen.height)
        {
            Screen.SetResolution((int) (Screen.height * (16f / 9f)), Screen.height, isFullscreen);
        }

        lastWidth = Screen.width;
        lastHeight = Screen.height;

    }

    
}