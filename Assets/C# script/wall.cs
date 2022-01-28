using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wall : MonoBehaviour
{
    public float Aspeed = -5;
    // Start is called before the first frame update
    void Start()
    {
        Aspeed = Random.Range(-6.0f, -4.0f);
        float rnd = Random.Range(-3.0f, 4.0f);              //벽이 랜덤한 높이 생성
        this.transform.position = new Vector3(0, rnd, 0);   //벽이 랜덤한 높이 생성
        Destroy(gameObject, 5.0f);//일정 시간이 지난 후  지나간 벽 제거
        //연결되어있는 wall 프리팹이 메모리에서 제거된다
        //5.0f는 5초뒤에 사라지게 한다
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Aspeed * Time.deltaTime, 0, 0);
    }
}
