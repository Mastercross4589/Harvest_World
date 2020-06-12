using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimHandTeleport : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform we want to teleport")]
    private Transform simHand;
    private LineRenderer teleportVisual;
    private Vector3 hitPosition;
    private bool shouldTeleport;
    void Start()
    {
        teleportVisual = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Do the visuals!
                hitPosition = hit.point;
                teleportVisual.SetPosition(0, transform.position);
                teleportVisual.SetPosition(1, hitPosition);
                teleportVisual.enabled = true;
                shouldTeleport = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            // Do the teleporting!
            if (shouldTeleport == true)
            {
                float offset = Offset();
                this.transform.position = new Vector3(hitPosition.x, hitPosition.y + offset, hitPosition.z);
                shouldTeleport = false;
                teleportVisual.enabled = false;
            }
        }
    }
    private float Offset()
    {
        RaycastHit offsetHit;
        if (Physics.Raycast(transform.position, -transform.up, out offsetHit))
        {
            Vector3 distance = transform.position - offsetHit.point;
            return distance.y;
        }
        else
        {
            return default;     // default float value is 0.0f. bool = false, string = null
        }
    }
}
