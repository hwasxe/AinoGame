using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBattery : MonoBehaviour
{
    public new Camera camera;
    public LayerMask mask;
    public Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {

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
            if (objectDetected != null){
                highlightMaterial = objectDetected.GetComponent<MeshRenderer>().material;
                highlightMaterial.EnableKeyword("_EMISSION");
                highlightMaterial.SetColor("_EmissionColor", Color.yellow);
            }
            

        }
        else
        {
            if(highlightMaterial!=null){
                highlightMaterial.DisableKeyword("_EMISSION");
                highlightMaterial.SetColor("_EmissionColor", Color.black);
                highlightMaterial = null;
                Debug.DrawLine(ray.origin, ray.origin+ray.direction * 5, Color.green);
            }
                
        }
    }
}