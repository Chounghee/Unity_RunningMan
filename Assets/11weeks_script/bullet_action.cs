using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bullet_action : MonoBehaviour
{
    public AudioClip collision_sound;
    public Transform explosion_effect;//prefab에 연결해야겠다는 것을 항상 기억하기!!

    void OnTriggerEnter(Collider other)//포탄과 물체가 닿으면
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Instantiate(explosion_effect, this.transform.position, this.transform.rotation);//포탄이 떨어진위치에 폭발이미지
            AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);//입체적인 사운드 출력(3D사운드)
            Destroy(other.gameObject);//포탄과 부딪힌 물체를 삭제
            Destroy(this.gameObject);//포탄이 물체와 부딪히면 포탄도 삭제
        }
        else if(other.gameObject.tag == "Enemy")
        {
            score_record.win++;
            if (score_record.win > 5)
                Destroy(other.transform.root.gameObject);
        }
        else if(other.gameObject.tag == "Tank")
        {
            score_record.lose++;
            if (score_record.lose > 5)
                Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score_record.win > 5)
        {
            SceneManager.LoadScene("win_screen");
            //SceneManager.LoadScene("scene1", LoadSceneMode.Single);
        }
    }
}
