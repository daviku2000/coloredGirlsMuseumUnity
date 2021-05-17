using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public LineRenderer lr;
    public float defaultLength = 5f;
    //public GameObject Dot;


    // Update is called once per frame
    void Update()
    {
        float targetLength = defaultLength;

        RaycastHit hit = createRaycast(targetLength);

        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        //Dot.transform.position = endPosition;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, endPosition);
    }

    private RaycastHit createRaycast(float targetLength)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }
}
