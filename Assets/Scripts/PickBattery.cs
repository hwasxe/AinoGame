using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickBattery : MonoBehaviour
{
    public new Camera camera;
    public LayerMask mask;
    public Material highlightMaterial;

    private BatteryCalculator batteryCalculator;
    // Start is called before the first frame update
    void Start()
    {
        batteryCalculator = GameObject.Find("BaterryText").GetComponent<BatteryCalculator>();
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
                highlightMaterial.SetColor("_EmissionColor", Color.yellow);
                
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    batteryCalculator.increaseBatteryNumber();
                    objectDetected.transform.gameObject.SetActive(false);
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
    }
}