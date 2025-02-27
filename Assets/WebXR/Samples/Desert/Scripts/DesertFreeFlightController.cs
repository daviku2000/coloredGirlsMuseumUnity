﻿using UnityEngine;
using WebXR;

public class DesertFreeFlightController : MonoBehaviour {
    [Tooltip("Enable/disable rotation control. For use in Unity editor only.")]
    public bool rotationEnabled = true;

    [Tooltip("Enable/disable translation control. For use in Unity editor only.")]
    public bool translationEnabled = true;

    public Transform body;

    private WebXRDisplayCapabilities capabilities;

    [Tooltip("Mouse sensitivity")]
    public float mouseSensitivity = 1f;

    [Tooltip("Straffe Speed")]
    public float straffeSpeed = 5f;

    private float minimumX = -360f;
    private float maximumX = 360f;

    private float minimumY = -90f;
    private float maximumY = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    Quaternion originalRotation;

    void Start()
    {
        WebXRManager.Instance.OnXRChange += onXRChange;
        WebXRManager.Instance.OnXRCapabilitiesUpdate += onXRCapabilitiesUpdate;
        originalRotation = transform.localRotation;
    }

    private void onXRChange(WebXRState state)
    {
        if (state == WebXRState.ENABLED)
        {
            DisableEverything();
        }
        else
        {
            EnableAccordingToPlatform();
        }
    }

    private void onXRCapabilitiesUpdate(WebXRDisplayCapabilities vrCapabilities)
    {
        capabilities = vrCapabilities;
        EnableAccordingToPlatform();
    }

    void Update() {
        if (translationEnabled)
        {
            float x =  Input.GetAxis("Horizontal") ;
            float z =  Input.GetAxis("Vertical") ;


            if (z > 0)
            body.transform.position += Vector3.Normalize(new Vector3(transform.forward.x * Time.deltaTime, 0f, transform.forward.z *Time.deltaTime)) * straffeSpeed;
            else if (z < 0)
                body.transform.position -= Vector3.Normalize(new Vector3(transform.forward.x * Time.deltaTime, 0f, transform.forward.z * Time.deltaTime)) * straffeSpeed;

            if (x > 0)
                body.transform.position += Vector3.Normalize(new Vector3(transform.right.x * Time.deltaTime, 0f, transform.right.z * Time.deltaTime)) * straffeSpeed;
            else if (x < 0)
                body.transform.position -= Vector3.Normalize(new Vector3(transform.right.x * Time.deltaTime, 0f, transform.right.z * Time.deltaTime )) * straffeSpeed;

        }

        if (rotationEnabled && Input.GetMouseButton(0))
        {

            rotationX += Input.GetAxis ("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis ("Mouse Y") * mouseSensitivity;

            rotationX = ClampAngle (rotationX, minimumX, maximumX);
            rotationY = ClampAngle (rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        
    }

    void DisableEverything()
    {
        translationEnabled = false;
        rotationEnabled = false;
    }

    /// Enables rotation and translation control for desktop environments.
    /// For mobile environments, it enables rotation or translation according to
    /// the device capabilities.
    void EnableAccordingToPlatform()
    {
        rotationEnabled = translationEnabled = !capabilities.supportsImmersiveVR;
    }

    public static float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp (angle, min, max);
    }
}
