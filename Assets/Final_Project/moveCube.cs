using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{
    public float startTime;

    public float minZ, maxZ;

    public float moveSpeed;

    private int sign = -1;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time >= startTime)
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * sign);

            if(transform.position.z <= minZ || transform.position.z >= maxZ)
            {
                sign *= -1;
            }
        }
    }
}
