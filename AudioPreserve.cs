using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPreserve : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
