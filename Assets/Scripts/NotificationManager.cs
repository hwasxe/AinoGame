using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("NotificationText");
        textObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNotification(string notification,int duration)
    {
        textObject.GetComponent<TMPro.TextMeshProUGUI>().text = notification;
        StartCoroutine(ResetAfterTime(duration));
    }
    IEnumerator ResetAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        textObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
