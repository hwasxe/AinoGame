using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCalculator : MonoBehaviour
{
    float CurrentTime;
    private GameObject batteryForeGroundBar;
    public GameObject txt;
    public GameObject spotlight;
    public float batterylevel = 100;
    public int batteryNumber = 0;

    private new Light light;
    // Start is called before the first frame update
    void Start()
    {
        batteryForeGroundBar = GameObject.Find("BatteryForeGround");
        
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery Number: "+batteryNumber.ToString()+("\n(Press R to reload)\nBattery level: %"+ batterylevel.ToString());
        batteryForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
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
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery Number: "+batteryNumber.ToString()+("\n(Press R to reload)\nBattery level: %"+ batterylevel.ToString());
        batteryForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
    }
    public void setBatteryLevel(float batteryLevel)
    {
        batterylevel = batteryLevel;
        updateTextShown();
    }
    public void setBatteryNumber(int batteryNo)
    {
        batteryNumber = batteryNo;
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
        GetComponent<TMPro.TextMeshProUGUI>().text = "Battery Number: "+batteryNumber.ToString()+("\n(Press R to reload)\nBattery level: %"+ batterylevel.ToString());
        batteryForeGroundBar.transform.localScale = new Vector3(batterylevel*(float)0.01, (float)0.9, 0);

    }
}