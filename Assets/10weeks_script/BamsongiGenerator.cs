using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;
    int count = 0;
    bool IsPause;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongi_prefab) as GameObject;//화면에 나타나게
            Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스가 클릭한 좌표를 읽어냄
            Vector3 shooting_ray = screen_ray.direction;//단위벡터를 뽑아냄
            //bamsongi.GetComponent<BamsongiCtrl>().Shoot(new Vector3(0, 500, 500));//위치변경하고 발사까지
            //위에꺼는 그냥 발사 밑에꺼는 위치에따라 발사위치 다르게
            bamsongi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray * 1000);//벡터방향으로 발사
            count++;
        }
       
        if(count > 5)
        {    
            Time.timeScale = 0;
        
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
            count = 0;

        }
        
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(61, Screen.height - 170, 128, 32), count.ToString());
        


    }
}
