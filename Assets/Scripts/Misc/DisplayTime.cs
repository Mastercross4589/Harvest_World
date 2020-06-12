using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public GameObject theDisplay;
    public int hour;
    public int minutes;

    // Start is called before the first frame update
    void Awake()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        theDisplay.GetComponent<Text>().text = "" + hour + ":" + minutes;
    }
}
