using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSound : MonoBehaviour
{
    public AudioSource mySfx;
    public AudioClip SpearSfx;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Spearsound();
            }
        }
    }
    public void Spearsound()
    {
        mySfx.PlayOneShot(SpearSfx);
    }
}
