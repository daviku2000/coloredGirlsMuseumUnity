using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyRotation : MonoBehaviour
{
    public Transform camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 newForward = Vector3.Normalize(new Vector3(camera.forward.x, 0f, camera.forward.z));
        transform.forward = newForward;
    }
}
