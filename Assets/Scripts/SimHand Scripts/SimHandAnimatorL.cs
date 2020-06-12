using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimatorL : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            simHandAnimator.SetBool("IsClosing", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            simHandAnimator.SetBool("IsClosing", false);
        }
    }
}
