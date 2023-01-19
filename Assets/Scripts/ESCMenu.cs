using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject endMenuUI;
    
    public float[] charPosition;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }
        }
    }

    public void Resume()
    {   
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause()
    {   
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SavePlayer()
    {
        float health = GameObject.Find("HealthBar").GetComponent<HealthCalculator>().healthlevel;
        float batteryLevel = GameObject.Find("BatteryBar").GetComponent<BatteryCalculator>().batterylevel;
        int firstaidnumber = GameObject.Find("HealthBar").GetComponent<HealthCalculator>().firstAidNumber;
        int batterynumber = GameObject.Find("BatteryBar").GetComponent<BatteryCalculator>().batteryNumber;
        charPosition = new float[3];
        var playerPosAxis = GameObject.Find("Player").GetComponent<PlayerController>().transform.position;
        charPosition[0] = playerPosAxis.x;
        charPosition[1] = playerPosAxis.y;
        charPosition[2] = playerPosAxis.z;
        SaveScript.SavePlayer(health, charPosition,batteryLevel,batterynumber,firstaidnumber);
        Debug.Log("Player data is SAVED successfully!!!");
    }
    
    public void LoadPlayer()
    {
        SaveData data = SaveScript.LoadPlayer();
        GameObject.Find("HealthBar").GetComponent<HealthCalculator>().setHealth(data.health);
        GameObject.Find("BatteryBar").GetComponent<BatteryCalculator>().setBatteryLevel(data.batteryLevel);
        GameObject.Find("HealthBar").GetComponent<HealthCalculator>().setFirstAidNumber(data.firstAidNumber);
        GameObject.Find("BatteryBar").GetComponent<BatteryCalculator>().setBatteryNumber(data.batteryNumber);
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.Find("Player").transform.position = new Vector3(data.charPosition[0],data.charPosition[1],data.charPosition[2]);
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
        Debug.Log("Player data is LOADED successfully!!!");
    }
}
