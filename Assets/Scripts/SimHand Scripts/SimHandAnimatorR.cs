using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimatorR : MonoBehaviour
{
    private Animator simHandAnimator;
    // Start is called before the first frame update
    void Start()
    {
        simHandAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosing", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosing", false);
        }
    }
}
