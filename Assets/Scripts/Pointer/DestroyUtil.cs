using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUtil : MonoBehaviour
{

    // Called from the Spawn animator
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
