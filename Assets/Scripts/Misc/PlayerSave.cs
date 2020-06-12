using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{

    public float time = 2f;

    public void Start()
    {
        LoadPlayer();
        InvokeRepeating("SaveAfterTime", 0, time);

    }

   public void SavePlayer()
    {
        SaveSystem.SavePlayer(this.gameObject);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    void SaveAfterTime()
    {
        SavePlayer();
    }
}
