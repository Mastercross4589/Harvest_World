using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        Settings.volume = slider.value;
    }
}
