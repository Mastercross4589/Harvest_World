using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Sun sun;
    private Light light;


    private void Awake()
    {
        light = GetComponent<Light>();
        sun = FindObjectOfType<Sun>();
    }

    // Start is called before the first frame update
    void Start()
    {
        light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float sunRotation = sun.transform.rotation.eulerAngles.x;
        
        if (sunRotation >= 0 && sunRotation < 180)
        {
            light.intensity = 0;
        }
        else
        {
            light.intensity = 1;
        }
    }
}
