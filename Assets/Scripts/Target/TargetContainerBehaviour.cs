using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContainerBehaviour : MonoBehaviour
{
    // Called by the end of the "Hide" animation
    public void DestroyChildTarget()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
