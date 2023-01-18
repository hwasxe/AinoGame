using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int flashlightLedLevel;
    public float health;
    public float[] charPosition;
    public SaveData(float playerHealth, float[] playerPos)
    {
        health = playerHealth;
        charPosition = playerPos;
    }
}
