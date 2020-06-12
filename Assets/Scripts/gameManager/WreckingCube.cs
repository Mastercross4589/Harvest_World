using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody cubeRigidbody;
    private WreckingResetButton resetButton;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        cubeRigidbody = GetComponent<Rigidbody>();

        resetButton.OnButtonPressed += ResetCubes;
    }

   public void ResetCubes()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        cubeRigidbody.velocity = Vector3.zero;
        cubeRigidbody.angularVelocity = Vector3.zero;

        GetComponent<Renderer>().enabled = true;
    }
}
