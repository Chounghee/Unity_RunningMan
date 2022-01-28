using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform targetTransform;

    public float dist = 3.5f;
    public float height = 2.0f;
    public float dampTrace = 20.0f;

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        _transform.position = Vector3.Lerp(_transform.position, targetTransform.position - (targetTransform.forward * dist) +
            (Vector3.up * height), Time.deltaTime * dampTrace);
        _transform.LookAt(targetTransform.position);//카메라가 타겟을 바라봄
    }
    void Update()
    {
        if(height > 0.5f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                height = height - 0.5f;
            }
        }
        if (height < 5.0f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                height = height + 0.5f;
            }
        }
        
        if (Input.GetKeyDown("r"))
        {
            dist = 3.5f;
            height = 2.0f;
        }
    }
}
