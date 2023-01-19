using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCalculator : MonoBehaviour
{
    float CurrentTime;
    public GameObject deadMenuUI;
    private GameObject healthForeGroundBar;
    public GameObject txt;
    public float healthlevel = 20;
    public int firstAidNumber = 0;
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        healthForeGroundBar = GameObject.Find("HealthForeGround");
        GetComponent<TMPro.TextMeshProUGUI>().text = "First-Aid-Kit Number: "+firstAidNumber.ToString()+"\n(Press H to use)"+("\nHealth: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (healthlevel <= 0 && !isDead)
        {
            isDead = true;
            //END GAME DIED!!!
            GameObject.Find("Player").GetComponent<CharacterController>().enabled = false;
            StartCoroutine(DeadEffect());
            
            Debug.Log("You Died!");
        }

    }
    
    IEnumerator DeadEffect() //Call this method with StartCoroutine(RotateForSeconds());
    {
        float time = 1;     //How long will the object be rotated?
 
        while(time > 0)     //While the time is more than zero...
        {
            GameObject.Find("Player").transform.Rotate((Vector3.down+Vector3.right) * 10 * Time.deltaTime);
            GameObject.Find("Player").transform.Rotate(Vector3.down+Vector3.right);    //...rotate the object.
            time -= Time.deltaTime;     //Decrease the time- value one unit per second.
 
            yield return null;     //Loop the method.
        }
        deadMenuUI.SetActive(true);
 
    }

    

    public void setHealthFull(){
        healthlevel = 100;
        GetComponent<TMPro.TextMeshProUGUI>().text = "First-Aid-Kit Number: "+firstAidNumber.ToString()+"\n(Press H to use)"+("\nHealth level: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3((float)0.99, (float)0.9, 0);
    }
    public void setHealth(float health){
        healthlevel = health;
        updateTextShown();
    }
    public void setFirstAidNumber(int firstAidNo)
    {
        firstAidNumber = firstAidNo;
        updateTextShown();
    }
    public void getDamageStrong()
    {
        Debug.Log("Strong Damage is taken!!!");
        if (healthlevel > 0)
        {
            healthlevel -= 20;
            updateTextShown();
        }
        
    }
    public void getDamageNormal()
    {
        Debug.Log("Normal Damage is taken!!!");
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
        GetComponent<TMPro.TextMeshProUGUI>().text = "First-Aid-Kit Number: "+firstAidNumber.ToString()+"\n(Press H to use)"+("\nHealth level: %"+ healthlevel.ToString());
        healthForeGroundBar.transform.localScale = new Vector3(healthlevel*(float)0.01, (float)0.9, 0);

    }
    
}
