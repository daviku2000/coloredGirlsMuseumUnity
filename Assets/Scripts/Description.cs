using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public string name;
    public string description;
    public AudioSource audio;

    public void playSound()
    {
        audio.Play();
        Debug.Log("PLAY");
    }
}