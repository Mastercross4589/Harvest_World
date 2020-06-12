using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSpread : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    public float pelletFireVel = 1;
    public Transform BarrelShotpoint;
    public SimHandGrabL simHandControllerL;
    public SimHandGrabR simHandControllerR;
    private GrabbableObjectSimHandR GrabbableObjectSimHandR;
    private GrabbableObjectSimHandL GrabbableObjectSimHandL;
    List<Quaternion> pellets;

    void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }

        GrabbableObjectSimHandR = GetComponent<GrabbableObjectSimHandR>();
        GrabbableObjectSimHandL = GetComponent<GrabbableObjectSimHandL>();

    }

    void Update()
    {
        //if(Input.GetButtonDown ("Fire1"))
        {
            //fire();
        }

        if (GrabbableObjectSimHandR.isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fire();
            }
        }
        if (GrabbableObjectSimHandL.isBeingHeld == true)
        { 
            if (Input.GetKeyDown(KeyCode.F))
            {
                fire();
            }
        }
    }

    void fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, BarrelShotpoint.transform.position, BarrelShotpoint.transform.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
            Destroy(p, 2f);
            i++;
        }
    }
}