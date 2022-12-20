using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCalculator : MonoBehaviour
{
    float CurrentTime;
       
    public GameObject txt;
    public GameObject spotlight;
    float batterylevel = 100;
    int batteryNumber = 0;

    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        updateTextShown();
        light = spotlight.GetComponent<Light>();
        light.intensity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if(CurrentTime > 4 && batterylevel>0){
            batterylevel = batterylevel - 5;
            light.intensity = (float)(batterylevel*0.1);
            updateTextShown();

            CurrentTime = 0;
        }
    
    }

    public void setBatteryFull(){
        batterylevel = 100;
        light.intensity = (float)(batterylevel*0.1);
        updateTextShown();
    }

    public void increaseBatteryNumber()
    {
        batteryNumber++;
        updateTextShown();
    }
    public void decreaseBatteryNumber()
    {
        batteryNumber--;
        updateTextShown();
    }

    public int getBatteryNumber()
    {
        return batteryNumber;
    }

    public void updateTextShown()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery level: "+ batterylevel.ToString()+"\nBattery Number: "+batteryNumber.ToString()+("\n(Press R to reload)");

    }
}