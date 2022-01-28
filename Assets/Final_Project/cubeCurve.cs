using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCurve : MonoBehaviour
{
    public int Speed;

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(new Vector3(0, Speed, 0) * Time.deltaTime);
    }
}
