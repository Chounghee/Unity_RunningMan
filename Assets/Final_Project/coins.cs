using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{   
    public float rotateSpeed;
   
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);//회전
    }
    

}
