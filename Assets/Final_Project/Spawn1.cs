using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject wallOb;

    IEnumerator Start() //IEnumerator는 일반 스타트함수와 다르게 실행되는순간
                        //별개의 스레드가 생성되서 계속해서 생성되게 된다
    {
        while (true)//무한루프
        {
            float rnd = Random.Range(1.0f, 8.0f);//벽이 생성되는 주기 랜덤
            Instantiate(wallOb, transform.position, transform.rotation);//wall 프리팹 생성
            yield return new WaitForSeconds(rnd);//1.5초 있다가 다시 함수로 반복
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
