using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossVRManager : MonoBehaviour
{
    public GameObject desktopCameraRig;
    public GameObject ovrCameraRig;
    public GameObject VRplayer;
    public GameObject XRController;

    void Awake()
    {
    #if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_EDITOR
        desktopCameraRig.SetActive(true);
        VRplayer.SetActive(true);
        ovrCameraRig.SetActive(false);
        XRController.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
#elif UNITY_OCULUS_VR
        ovrCameraRig.SetActive(true);
        XRController.SetActive(true);
        desktopCameraRig.SetActive(false);
        VRplayer.SetActive(false);
        
#endif
    }
}
