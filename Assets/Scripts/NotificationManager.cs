using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private GameObject textObject;
    public GameObject pageObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("NotificationText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            pageObject.SetActive(false);
        }
    }

    public void SetNotification(string notification,int duration)
    {
        GameObject.Find("NotificationText").GetComponent<TMPro.TextMeshProUGUI>().text = notification;
        StartCoroutine(ResetAfterTime(duration));
    }

    public void ShowPage(string text)
    {
        pageObject.SetActive(true);
        GameObject.Find("PageText").GetComponent<TextMeshProUGUI>().text = text;
        
    }
    
    IEnumerator ResetAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        textObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
