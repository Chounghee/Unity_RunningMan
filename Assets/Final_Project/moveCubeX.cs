using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCubeX : MonoBehaviour
{
    public float startTime;

    public float minX, maxX;

    public float moveSpeed;

    private int sign = -1;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.time >= startTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}
