using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_prefab : MonoBehaviour
{
    public float speed = -5;

    void Start()
    {
        speed = Random.Range(-6.0f, -4.0f);
        float rnd = Random.Range(0.0f, 5.0f);              
        this.transform.position = new Vector3(0, 0, 15);  
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
