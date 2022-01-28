using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jump_power = 5;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
         jump_power = Random.Range(5, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))//space바 버튼이 Jump로 지정되어있다
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump_power, 0);
        //velocity는 속도이다. 속도를 재지정하는것
        //아무리 떨어져도 space바 누르면 위로 점프가 된다
        //addforce와 살짝 다르다
        time+=Time.deltaTime;
        
    }
    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("main_scene");
    }
    void OnGUI()
    {       
        GUI.Label(new Rect(81, Screen.height - 40, 128, 32), time.ToString());
        GUI.Label(new Rect(40, Screen.height - 40, 128, 32), jump_power.ToString());

    }
}
