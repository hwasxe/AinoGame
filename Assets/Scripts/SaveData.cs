using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float batteryLevel;
    public int batteryNumber;
    public int firstAidNumber;
    public float health;
    public float[] charPosition;
    public SaveData(float playerHealth, float[] playerPos,float playerBatteryLevel, int playerBatteryNumber, int playerFirstAidNumber)
    {
        firstAidNumber = playerFirstAidNumber;
        batteryNumber = playerBatteryNumber;
        batteryLevel = playerBatteryLevel;
        health = playerHealth;
        charPosition = playerPos;
    }
}
