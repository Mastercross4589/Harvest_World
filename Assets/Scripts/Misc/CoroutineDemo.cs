using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MyCourotine());
        Debug.Log("Something");
        
    }

    IEnumerator MyCourotine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("1 second passed");
        yield return new WaitForSeconds(3);
        Debug.Log("more 3 seconds passed");

        while (true)
        {
            Debug.Log("infinite loop");
            yield return new WaitForEndOfFrame();
        }
    }
}
