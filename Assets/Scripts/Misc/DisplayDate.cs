using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour
{
    public GameObject theDisplay;
    public int day;
    public int month;
    public int year;

    // Start is called before the first frame update
    void Awake()
    {
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
    }

    // Update is called once per frame
    void Update()
    {
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
        theDisplay.GetComponent<Text>().text = "" + day + "/" + month + "/" + year;
    }
}
