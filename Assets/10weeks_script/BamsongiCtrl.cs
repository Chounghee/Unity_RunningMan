using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    float timer = 0.0f;
    bool is_shot = false;//발사했는지 확인하는 함수
    float x = 0.0f;
    float y = 0.0f;
    int score = 0;
    static int total = 0;
    int count = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        /*if(timer> 0.05 && !is_shot)//0.05초 후나 쏜적이 없으면
        {
            Shoot(new Vector3(0, 500, 600));//발사함수
            is_shot = true;//한번만쏘고 더 쏘지 않는다
        }*/
        if (Input.GetKeyDown(KeyCode.R))
        {
            total = 0;
        }


    }
    public void Shoot(Vector3 dir)//발사함수
    {
        GetComponent<Rigidbody>().AddForce(dir);
        x = Random.Range(-4.0f, 4.0f);
        y = Random.Range(-1.0f, 4.0f);
        Physics.gravity = new Vector3(x, y, 0);
    }
    void OnCollisionEnter(Collision other)//물리력 무효화
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        //점수를 넣기 위해서 추가한 함수들
        Vector3 collided_position = transform.position;//밤송이가 충돌한 위치
        float distance = collided_position.x * collided_position.x +
            (collided_position.y - 6.5f) * (collided_position.y - 6.5f);//피타고라스
        distance = Mathf.Sqrt(distance);//루트값
        Debug.Log(collided_position);//위치 얼마인지 살펴보고
        Debug.Log(distance);//거리 얼마인지 살펴보고

        if(distance > 0.0f && distance < 0.4f)
        {
            score = 100;
        }
        if(distance > 0.4f && distance < 0.8f)
        {
            score = 90;
        }
        if (distance > 0.8f && distance < 1.2f)
        {
            score = 70;
        }
        if (distance > 1.2f && distance < 1.6f)
        {
            score = 50;
        }
        if (distance > 1.6f && distance < 2.0f)
        {
            score = 30;
        }
        if (distance > 2.0f)
        {
            score = 0;
        }
        total += score;
        
    }
    void OnGUI()
    {
        //GUI.Label(new Rect(61, Screen.height - 170, 128, 32), count.ToString());
        GUI.Label(new Rect(81, Screen.height - 170, 128, 32), total.ToString());
        GUI.Label(new Rect(61, Screen.height - 150, 128, 32), Physics.gravity.ToString());
       

    }
}
