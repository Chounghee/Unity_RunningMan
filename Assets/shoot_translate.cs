using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_translate : MonoBehaviour
{
    float speed = 5.0f;//큐브 스피드는 5
    public float power = 500.0f;//발사의 스피드는 500
    public GameObject ball;//새로운 오브젝트 ball생성
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance_per_frame = speed * Time.deltaTime;//타임델타타임으로 프레임당 얼마 움직일지 결정 1초에 5만큼 이동
        float vertical_input = Input.GetAxis("Vertical");//수직방향으로 입력 들어왔는지 저장
        float horizontal_input = Input.GetAxis("Horizontal");//수평방향으로 입력 들어왔는지 저장
        Vector3 launch_direction = new Vector3(0, 1, 1);//방향

        transform.Translate(Vector3.forward * vertical_input * distance_per_frame);//위 1 아래 -1 이동
        transform.Translate(Vector3.right * horizontal_input * distance_per_frame);//오른쪽 1 왼쪽 -1 이동

        if (Input.GetButtonDown("Fire1"))//마우스왼쪽과 L+ctrl을 누르면 발사
            ball.GetComponent<Rigidbody>().AddForce(launch_direction * power);
        
    }
}
