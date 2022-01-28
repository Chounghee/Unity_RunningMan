using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_turret_move : MonoBehaviour
{
    [SerializeField]
    private float power = 1200.0f;
    private float elapsed_time = 0.0f;//적군의 사격 지연시간적용을 위해 넣음
    public float fire_interval = 2.0f;//적군의 포탄을 쏠때 2초간격으로
    public Transform bullet;//포탄 prefab
    public Transform target;//아군 탱크
    public Transform sp_point;//적군 탱크의 spawn point

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);//적군이 항상 아군 탱크를 주시
        elapsed_time += Time.deltaTime;//적군의 사격 시간 더하기

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);//앞방향

        Debug.DrawRay(sp_point.transform.position, fwd * 5, Color.green);
        //반직선(Ray)을 쏴서 부딪힌 물체가 있을 경우 true 반환
        //out hit : 반직선에 부딪힌 물체에 대한 정보 포함
        if (Physics.Raycast(sp_point.transform.position, fwd, out hit, 5) == false
            //                      반직선 시작점         방향          길이
            || hit.collider.gameObject.tag != "Tank"
            || elapsed_time < fire_interval)//포탄을 쏜지 2초가 지나지 않았다면
            return;
        Debug.Log(hit.collider.gameObject.name);
        Transform enemy_bullet = Instantiate(bullet, sp_point.transform.position, Quaternion.identity);//회전 초기값
        enemy_bullet.GetComponent<Rigidbody>().AddForce(fwd * power);
        elapsed_time = 0.0f;//포탄을 쏜 시간 0초 초기화
    }
}
