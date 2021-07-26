using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    public Transform thisObj;
    public Transform mainCam;
    public Transform leftEye;
    public Transform rightEye;

    // Update is called once per frame
    void Update()
    {
        if (mainCam.gameObject.activeInHierarchy)
        {
            thisObj = mainCam;
        }
        else if (leftEye.gameObject.activeInHierarchy)
        {
            thisObj = leftEye;
        }
        else
        {
            thisObj = rightEye;
        }

        float ver = Input.GetAxis("Horizontal");
        float hor = Input.GetAxis("Vertical");

        Vector3 newForward = Vector3.Normalize(new Vector3(thisObj.transform.forward.x, 0f, thisObj.transform.forward.z));
        Vector3 newRight = Vector3.Normalize(new Vector3(thisObj.transform.right.x, 0f, thisObj.transform.right.z));

        

        if (hor > 0) transform.position += newForward * speed*Time.deltaTime;
        else if(hor<0) transform.position -= newForward * speed * Time.deltaTime;

        if (ver > 0) transform.position += newRight*speed * Time.deltaTime;
        else if (ver < 0) transform.position -= newRight * speed * Time.deltaTime;
    }
}
