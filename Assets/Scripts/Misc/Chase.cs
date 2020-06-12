using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform target;
    public int moveSpeed = 1;
    public float stoppingDistance = 2f;
    public bool startStop = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (!startStop)
        {
            transform.position = this.transform.position;
        }
        else
        {
            StartMove();
        }

    }

    void StartMove()
    {
        //if (Vector3.Distance(transform.position, target.position) < stoppingDistance.position)
        {

        }
        transform.Translate(Vector3.forward);
    }


}
