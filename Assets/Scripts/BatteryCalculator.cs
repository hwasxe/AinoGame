using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCalculator : MonoBehaviour
{
    float CurrentTime;
       
    public GameObject txt;
    public GameObject spotlight;
    float batterylevel = 50;

    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery level: "+ batterylevel.ToString();
        light = spotlight.GetComponent<Light>();
        light.intensity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if(CurrentTime > 4 && batterylevel>0){
            batterylevel = batterylevel - 10;
            light.intensity = (float)(batterylevel*0.1);
            GetComponent<TMPro.TextMeshProUGUI>().text = "Battery level: "+ batterylevel.ToString();

            CurrentTime = 0;
        }
    
    }

    void getBatteryFull(){
        batterylevel = 100;
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery level: "+ batterylevel.ToString();
    }
}