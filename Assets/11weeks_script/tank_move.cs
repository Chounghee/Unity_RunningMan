using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_move : MonoBehaviour
{
    private float tank_speed = 5.0f;
    private float rot_speed = 120.0f;
    public GameObject turret;//inspector에서 포탑(turret) 연결
    public float bullet_power = 600.0f;
    public Transform bullet;//prefab에있는 bullet을 연결
    public GameObject barrel;

    void Start()
    {
        
    }

    
    void Update()
    {
        float distance_per_frame = tank_speed * Time.deltaTime;//얼마나 움직일 것인가
        float degrees_per_frame = rot_speed * Time.deltaTime;//얼마나 회전할 것인가

        float moving_velocity = Input.GetAxis("Vertical");//위쪽방향키눌렀을때 양의값, 아래방향키눌렀을때 음의값
        float tank_angle = Input.GetAxis("Horizontal");
        float turret_angle = Input.GetAxis("TurretRotation");//input manager를 통해 이름 변경

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame);//탱크의 전후 이동
        this.transform.Rotate(0.0f,tank_angle * degrees_per_frame, 0.0f);//탱크의 회전, y축으로 회전한다
        turret.transform.Rotate(Vector3.up * turret_angle * degrees_per_frame * 0.5f);//포탑의 회전

        if (Input.GetButtonDown("Fire1"))//왼클릭하면 발사
        {//포탑의 끝에서 발사가 되야한다->위치수정해야한다
            GameObject spawn_point = GameObject.Find("sp_bullet");
            //Transform prefab_bullet = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
            //위에꺼는 bullet을 turret위치에서 생성 밑에꺼는 bullet을 spawn_point에서 생성
            Transform prefab_bullet = Instantiate(bullet, spawn_point.transform.position, spawn_point.transform.rotation);
            //prefab_bullet.GetComponent<Rigidbody>().AddForce(turret.transform.forward * bullet_power);
            //위에꺼는 그냥 발사 밑에꺼는 함수를 수정하여 spawn_point위치에서 발사
            prefab_bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.up * bullet_power);
        }
    }
}
