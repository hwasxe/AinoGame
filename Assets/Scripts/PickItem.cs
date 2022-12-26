
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public new Camera camera;
    public LayerMask mask;
    public Material highlightMaterial;
    private BatteryCalculator batteryCalculator;
    private HealthCalculator healthCalculator;

    // Start is called before the first frame update
    void Start()
    {
        batteryCalculator = GameObject.Find("BatteryBar").GetComponent<BatteryCalculator>();
        healthCalculator = GameObject.Find("HealthBar").GetComponent<HealthCalculator>();

    }

    // Update is called once per frame
    void Update()
    {
        var ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2, mask))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            var objectDetected = hitInfo.collider;
            if (objectDetected != null)
            {
                highlightMaterial = objectDetected.GetComponent<MeshRenderer>().material;
                highlightMaterial.EnableKeyword("_EMISSION");
                highlightMaterial.SetColor("_EmissionColor", Color.gray);

                if (hitInfo.transform.gameObject.CompareTag("Battery"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        batteryCalculator.increaseBatteryNumber();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                if (hitInfo.transform.gameObject.CompareTag("MainDoorKey"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("You got the Main Dor Key! Now you can open the Main door...");
                        GameObject.Find("MainDoor").GetComponent<DoorController>().SetKeyTakenTrue();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                
                if (hitInfo.transform.gameObject.CompareTag("FirstAidKit"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject.Find("HealthBar").GetComponent<HealthCalculator>().increaseFirstAidNumber();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                
            }

        }
        else
        {
            if (highlightMaterial != null)
            {
                highlightMaterial.DisableKeyword("_EMISSION");
                highlightMaterial.SetColor("_EmissionColor", Color.black);
                highlightMaterial = null;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (batteryCalculator.getBatteryNumber() > 0)
            {
                batteryCalculator.setBatteryFull();
                batteryCalculator.decreaseBatteryNumber();
            }
            else
            {
                        //Here we can make error noice because not enough battery
            }

        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (healthCalculator.getFirstAidNumber() > 0)
            {
                healthCalculator.setHealthFull();
                healthCalculator.decreaseFirstAidNumber();
            }
            else
            {
                //Here we can make error noice because not enough fir aid
            }

        }
    }
}