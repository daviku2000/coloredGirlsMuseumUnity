using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Camera mainCam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.gameObject.GetComponent<Description>() != null)
                {
                    hit.collider.gameObject.GetComponent<Description>().playSound();
                    Debug.Log("sds");
                }
            }
        }

        else if (Input.GetAxis("TriggerLeft") !=0)
        {
            Debug.Log("Trigger pressed");
        }
    }
}