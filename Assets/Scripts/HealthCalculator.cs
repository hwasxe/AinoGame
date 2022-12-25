using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCalculator : MonoBehaviour
{
    float CurrentTime;
    private GameObject healthForeGroundBar;
    public GameObject txt;
    float healthlevel = 100;
    int firstAidNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        healthForeGroundBar = GameObject.Find("HealthForeGround");
        GetComponent<TMPro.TextMeshProUGUI>().text = "\nFirst-Aid-Kit Number: "+firstAidNumber.ToString()+("\nHealth: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthlevel <= 0)
        {
            //Ölme Kodu Buraya yazılacak. Yere düşme animasyonu oluştur
        }

        
    
    }

    public void setHealthFull(){
        healthlevel = 100;
        GetComponent<TMPro.TextMeshProUGUI>().text = "\nFirst-Aid-Kit Number: "+firstAidNumber.ToString()+("\nHealth level: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
    }
    public void getDamageStrong()
    {
        if (healthlevel > 0)
        {
            healthlevel -= 20;
            updateTextShown();
        }
        
    }
    public void getDamageNormal()
    {

        if (healthlevel > 0)
        {
            healthlevel -= 10;
            updateTextShown();
        }
    }

    public void increaseFirstAidNumber()
    {
        firstAidNumber++;
        updateTextShown();
    }
    public void decreaseFirstAidNumber()
    {
        firstAidNumber--;
        updateTextShown();
    }

    public int getFirstAidNumber()
    {
        return firstAidNumber;
    }

    public void updateTextShown()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "\nFirst-Aid-Kit Number: "+firstAidNumber.ToString()+("\nHealth level: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3(healthlevel*(float)0.01, (float)0.9, 0);

    }
    
}
