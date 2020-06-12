using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WreckingResetButton : MonoBehaviour
{
    //public AudioSource buttonClick;
    public Animator buttonAnim;
    public UnityEvent buttonPressedEvent;
    public delegate void ButtonTuningForkEvent();
    public ButtonTuningForkEvent OnButtonPressed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");
            buttonPressedEvent?.Invoke();
            OnButtonPressed();
        }
    }
}
