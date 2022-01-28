using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_creator : MonoBehaviour
{
    public static float x=0.0f;
    public static float BLOCK_WIDTH = 1.0f;
    public static float BLOCK_HEIGHT = 1.0f;
    public static int BLOCK_NUM_IN_SCREEN = 24;
    //한 화면에 블록이 나타나야 하는 갯수가 24개
    private level_control lev_ctrl = null;//level_control때문에 추가한 것

    private float Timeleft = 2.0f;
    private float nexttime = 0.0f;

    private struct FloorBlock//구조체 생성
    {
        public bool is_created;  //특정한 위치에 블록이 생성됬는지 확인
        public Vector3 position;
    };

    private FloorBlock last_block;//마지막에 생성한 블록의 정보를 기록할 변수
    private player_control player = null;
    private block_creator block;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_control>();
        last_block.is_created = false;
        block = gameObject.GetComponent<block_creator>();

        lev_ctrl = new level_control();//level_control때문에 추가한 것
        lev_ctrl.Initialize();         //level_control때문에 추가한 것
        StartCoroutine(heightcontrol());
    }
    IEnumerator heightcontrol()
    {
        while (true)
        {
            x = 0.0f;         
            yield return new WaitForSecondsRealtime(5.0f);
            x = Random.Range(-1.0f, 1.0f);            
            yield return new WaitForSecondsRealtime(5.0f);
            x = Random.Range(-2.0f, 2.0f);           
            yield return new WaitForSecondsRealtime(5.0f);
            x = Random.Range(-2.0f, 2.0f);           
            yield return new WaitForSecondsRealtime(5.0f);
            x = Random.Range(-1.0f, 1.0f);           
            yield return new WaitForSecondsRealtime(5.0f);
        }


    }

    private void CreateFloorBlock()
    {
        Vector3 block_position;

        if (!last_block.is_created)
        {
            block_position = player.transform.position;
            block_position.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
            block_position.y += BLOCK_HEIGHT * x;
        }
        else
        {
            block_position = last_block.position;
        }
        block_position.x += BLOCK_WIDTH;

        //block.CreateBlock(block_position);
        lev_ctrl.UpdateStatus();                                        //구멍 생성때문에 수정

        block_position.y = lev_ctrl.current_block.height * BLOCK_HEIGHT;//구멍 생성때문에 수정
        level_control.CreationInfo current = lev_ctrl.current_block;   //구멍 생성때문에 수정

        if (current.block_type == Block.TYPE.FLOOR)                     //구멍 생성때문에 수정
            block.CreateBlock(block_position);                          //구멍 생성때문에 수정

        last_block.position = block_position;
        last_block.is_created = true;
    }
    // Update is called once per frame
    void Update()
    {
        float block_generate_x = player.transform.position.x;

        block_generate_x += BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN +1) / 2.0f;//25/2 

        while(last_block.position.x < block_generate_x)
        {
            CreateFloorBlock();
        }
    }
    public bool IsGone(GameObject block_object)//플레이어 위치로 부터 왼쪽 끝보다 나가면 블록을 없앤다
    {
        bool result = false;

        float left_limit = player.transform.position.x - BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);

        if (block_object.transform.position.x < left_limit)
            result = true;
        return result;
    }
}
