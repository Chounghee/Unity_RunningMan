using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishsound : MonoBehaviour
{
    AudioSource audio;
    
    void Awake()
    {
        audio = GetComponent<AudioSource>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
        }
    }
}
