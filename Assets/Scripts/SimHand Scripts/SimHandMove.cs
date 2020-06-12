using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimHandMove : MonoBehaviour
{
    public Transform location;
    private Vector3 otherLocation = new Vector3(500f, 50f, 500f);
    private Rigidbody VRplayerRigidbody;
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        VRplayerRigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
         Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed);
        #region translational movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            VRplayerRigidbody.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        #endregion
        #region rotation using keyboard
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        #endregion
        #region rotation using mouse
        //transform.Rotate(Vector3.up );
        #endregion
    }
    void Peter()
    {
        transform.position = otherLocation;
    }
}
