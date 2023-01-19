using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveScript 
{
    public static void SavePlayer(float playerHealth, float[] playerPos, float playerBatteryLevel, int playerBatteryNumber, int playerFirstAidNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("BATTERY LEVEL IS SAVINGGGGG ::::::: :"+ playerBatteryLevel);
        SaveData data = new SaveData(playerHealth,playerPos,playerBatteryLevel,playerBatteryNumber,playerFirstAidNumber);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            Debug.Log("Health is Loaded from save :"+ data.health);
            Debug.Log("Battery is Loaded from save :"+ data.batteryLevel);
            Debug.Log("Position is Loaded from save :"+ data.charPosition[0]+", "+data.charPosition[1]+", "+data.charPosition[2]);
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
    
}
