using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class reset : MonoBehaviour
{
    public int totallItemCount;
    public int stage;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.tag == "Player")
        {
            audio.Play();
            SceneManager.LoadScene(stage);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
