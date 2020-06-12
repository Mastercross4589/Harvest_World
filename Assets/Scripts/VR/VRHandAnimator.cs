using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private VRInput Controller;
    private Animator vrHandAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        Controller = GetComponent<VRInput>();
        vrHandAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Controller)
        {
            vrHandAnimator.Play("Fist Closing", 0, Controller.gripValue);
        }
    }
}
