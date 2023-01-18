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
    public float health;
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause()
    {   
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SavePlayer()
    {
        health = GameObject.Find("HealthBar").GetComponent<HealthCalculator>().healthlevel;
        charPosition = new float[3];
        var playerPosAxis = GameObject.Find("Player").GetComponent<PlayerController>().transform.position;
        charPosition[0] = playerPosAxis.x;
        charPosition[1] = playerPosAxis.y;
        charPosition[2] = playerPosAxis.z;
        SaveScript.SavePlayer(health, charPosition);
    }
    
    public void LoadPlayer()
    {
        SaveData data = SaveScript.LoadPlayer();
        health = GameObject.Find("HealthBar").GetComponent<HealthCalculator>().healthlevel;
        health = data.health;
        Vector3 position;
        position.x = data.charPosition[0];
        position.y = data.charPosition[1];
        position.z = data.charPosition[2];
        GameObject.Find("Player").GetComponent<PlayerController>().transform.position = position;
    }
}
