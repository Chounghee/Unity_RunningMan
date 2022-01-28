using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform _transform;
    private float _horizontal = 0.0f;
    private float _vertical = 0.0f;

    public float moveSpd = 15.0f;
    public float rotateSpd = 100.0f;
    public float jump_power = 5;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        _vertical = Input.GetAxis("Vertical");

        Vector3 moveDirect = (Vector3.forward * _vertical) + (Vector3.right * _horizontal);

        _transform.Translate(moveDirect.normalized * Time.deltaTime * moveSpd, Space.Self);
        //_transform.Rotate(Vector3.up * Time.deltaTime * rotateSpd * Input.GetAxis("Mouse X"));

        if (Input.GetButtonDown("Jump"))//space바 버튼이 Jump로 지정되어있다
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump_power, 0);
    }
}
