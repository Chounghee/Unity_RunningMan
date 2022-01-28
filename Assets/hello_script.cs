
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hello_script : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//이동
        {
            float rnd = Random.Range(-0.2f, 0.2f);
            this.transform.position += new Vector3(rnd, rnd, rnd);
        }
        if (Input.GetKeyDown(KeyCode.B))//회전
        {
            float rnd = Random.Range(0.0f, 360.0f);
            this.transform.rotation = Quaternion.Euler(rnd, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.C))//확대축소
        {
            float rnd = Random.Range(0.5f, 1.5f);
            this.transform.localScale = new Vector3(rnd,rnd, rnd);
        }
        if (Input.GetKey(KeyCode.UpArrow))//방향키위 눌렀을때 z축 이동
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, 3.0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R))//물체의 회전1초에 90도 회전
        {
            this.transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f);
        }
    }
}
