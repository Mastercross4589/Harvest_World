using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    // public int //I'll use these later
    // public int //I'll use these later
    public float[] position;

    public PlayerData(GameObject player) // Saves player location, also "Player" is showing an error
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }


}
