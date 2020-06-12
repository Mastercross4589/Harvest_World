using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringAction : MonoBehaviour
{
    public int particleCount;
    public float spreadAngle;
    public GameObject waterParticle;
    public float particleFireVel = 1;
    public Transform waterCanHead;
    public SimHandGrabL simHandControllerL;
    public SimHandGrabR simHandControllerR;
    private GrabbableObjectSimHandR GrabbableObjectSimHandR;
    private GrabbableObjectSimHandL GrabbableObjectSimHandL;
    List<Quaternion> water;

   
    void Awake()
    {
        water = new List<Quaternion>(particleCount);
        for (int i = 0; i < particleCount; i++)
        {
            water.Add(Quaternion.Euler(Vector3.zero));
        }

        GrabbableObjectSimHandR = GetComponent<GrabbableObjectSimHandR>();
        GrabbableObjectSimHandL = GetComponent<GrabbableObjectSimHandL>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
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
        for (int i = 0; i < particleCount; i++)
        {
            water[i] = Random.rotation;
            GameObject w = Instantiate(waterParticle, waterCanHead.transform.position, waterCanHead.transform.rotation);
            w.transform.rotation = Quaternion.RotateTowards(w.transform.rotation, water[i], spreadAngle);
            w.GetComponent<Rigidbody>().AddForce(w.transform.forward * particleFireVel);
            Destroy(w, 1f);
            i++;
        }
    }
}
