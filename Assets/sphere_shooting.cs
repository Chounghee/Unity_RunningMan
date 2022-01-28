using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_shooting : MonoBehaviour
{
    public float power = 500.0f;//발사 속도
    public GameObject ball;//ball
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision coll)//충돌 발생시 호출
    {
        Vector3 launch_direction = new Vector3(0, 1, 1);//방향
        if (coll.gameObject.name == "Cube")//Cube에 닿으면
        {
            ball.GetComponent<Rigidbody>().AddForce(launch_direction * power);//발사
        }
    }
}