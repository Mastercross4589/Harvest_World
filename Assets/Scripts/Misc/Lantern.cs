using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject LanternCage;
    public GameObject Candlelight;
    public SimHandGrabL simHandControllerL;
    public SimHandGrabR simHandControllerR;
    public bool isBeingHeld;
    private GrabbableObjectSimHandR GrabbableObjectSimHandR;
    private GrabbableObjectSimHandL GrabbableObjectSimHandL;
    private bool Active;


    // Start is called before the first frame update
    void Awake()
    {
        Candlelight.SetActive(false);
        Active = false;

        GrabbableObjectSimHandR = GetComponent<GrabbableObjectSimHandR>();
        GrabbableObjectSimHandL = GetComponent<GrabbableObjectSimHandL>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabbableObjectSimHandL.isBeingHeld == true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (Active == false)
                {
                    Candlelight.SetActive(true);
                    Active = true;
                    print("Active");
                }
                else
                {
                    if (Active == true)
                    {
                        Candlelight.SetActive(false);
                        Active = false;
                        print("Inactive");
                    }
                }
            }
        }
        if (GrabbableObjectSimHandR.isBeingHeld == true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (Active == false)
                {
                    Candlelight.SetActive(true);
                    Active = true;
                    print("Active");
                }
                else
                {
                    if (Active == true)
                    {
                        Candlelight.SetActive(false);
                        Active = false;
                        print("Inactive");
                    }
                }
            }
        }

        //RaycastHit hit;
        //if (Physics.Raycast(LanternCage.transform.position, LanternCage.transform.rotation))
        //{
            //Chase.startStop = Candlelight.SetActive(false);
        //}
    }

    void OilLantern()
    {
        

    }
}
