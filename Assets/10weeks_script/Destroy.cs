using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject player;
    int count=0;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            GameObject.Destroy(gameObject);
        }
        if (count > 1)
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
        }
    }
}
