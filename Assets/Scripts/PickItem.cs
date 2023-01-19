
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
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You got 1 Battery ",4);
                        batteryCalculator.increaseBatteryNumber();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                if (hitInfo.transform.gameObject.CompareTag("MainDoorKey"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You got the Main Dor Key! Now you can open the Main door...",5);
                        GameObject.Find("MainDoor").GetComponent<KeyDoorController>().SetKeyTakenTrue();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                
                if (hitInfo.transform.gameObject.CompareTag("FirstAidKit"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You got First-Aid-Kit",4);
                        GameObject.Find("HealthBar").GetComponent<HealthCalculator>().increaseFirstAidNumber();
                        objectDetected.transform.gameObject.SetActive(false);
                    }
                    
                }
                
                if (hitInfo.transform.gameObject.CompareTag("ClipBoard"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().ShowPage("After the queen's battle destroyed nearly everything.\nKing's come face to face for a final battle against each other." +
                            "\nOne side is protected by a white heroic horse,\nwhile the other side attacks with black bishop and a pitch black rook\nAll of a sudden white king, illuminating the darkness of the night, comes to reverse the events");
                    }
                    
                }
                if (hitInfo.transform.gameObject.CompareTag("Laptop"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You got the Laptop!! You can Leave the Valley!!!",4);
                        GameObject.Find("EndGameController").GetComponent<EndGameController>().EndTheGame();
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