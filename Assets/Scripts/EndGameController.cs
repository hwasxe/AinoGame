using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameController : MonoBehaviour
{
    private bool endGameCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You need to do .......... then leave the Valley!!! ",10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            if (endGameCondition)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(2);
                
            }
            else
            {
                GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You can not leave the Valley right now !!! ",4);
            }
            
        }
    }
    public void EndTheGame()
    {
        endGameCondition = true;
    }
    
}
