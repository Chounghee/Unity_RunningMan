using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercoin : MonoBehaviour
{
    public int itemCount;
    AudioSource audio;
    public int stage;
    public Text coinText;


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
        if(other.tag == "coin")
        {
            itemCount = itemCount + 100;
            audio.Play();
            other.gameObject.SetActive(false);
            coinText.text = itemCount+"";
            
            
        }
        else if(other.tag == "Finish")
        {

            SceneManager.LoadScene(stage);
        }
        else if(other.tag == "Spear")
        {
            
            SceneManager.LoadScene(2);
        }
        else if (other.tag == "Saw")
        {

            SceneManager.LoadScene(2);
        }
    }
   
}
