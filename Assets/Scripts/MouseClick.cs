using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                if(hit.collider.gameObject.GetComponent<Description>() != null)
                {
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }
}
