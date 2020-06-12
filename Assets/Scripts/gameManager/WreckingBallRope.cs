using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WreckingBallRope : MonoBehaviour
{
    public Transform wreckingArm, wreckingBall;
    private LineRenderer rope;

    void Start()
    {
        rope = GetComponent<LineRenderer>();
    }

    void Update()
    {
        rope.SetPosition(0, wreckingArm.position);
        rope.SetPosition(1, wreckingBall.position);
    }
}
