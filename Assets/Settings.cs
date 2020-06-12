using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static float volume = 1f;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
