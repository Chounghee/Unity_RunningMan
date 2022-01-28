using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//매개변수인 Player를 찾는다
        position_offset = transform.position - player.transform.position;
        //카메라 위치-플레이어 상대적 위치
    }

    // Update is called once per frame
    void LateUpdate()//LateUpdate = 모든 게임 오브젝트의 Update처리가 끝난 후 자동실행
        //플레이어가 위치가 변경된 후에 작업할려면 이LateUpdate 쓴다
        //플레이어가 움직이면 카메라도 따라 움직이게
    {
        Vector3 new_position = transform.position;//카메라 위치
        new_position.x = player.transform.position.x + position_offset.x;
        //플레이어가 움직인 위치x + 카메라 사이의 위치x
        transform.position = new_position;
    }
}
