using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public static float ACCELERATION = 10.0f;
    public static float SPEED_MIN = 4.0f;
    public static float SPEED_MAX = 8.0f;
    public static float JUMP_HEIGHT_MAX = 3.0f;
    public static float JUMP_POWER_REDUCE = 0.5f;
    public static float FAIL_LIMIT = -5.0f;
    public float time = 0;

    public enum STEP
    {
        NONE = -1,
        RUN = 0,
        JUMP,
        MISS,
        NUM,//num은 열거형 타입의 기본?적으로 쓴다 .코딩에 의미있는 상태의 개수
    };

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;

    public float step_timer = 0.0f;
    private bool is_landed = false;
    private bool is_collided = false;
    private bool is_key_released = false;
    
    private void CheckLanded()
    {
        is_landed = false;

        do
        {
            Vector3 current_position = transform.position;
            Vector3 down_position = current_position + Vector3.down * 1.0f;

            RaycastHit hit;
            if (!Physics.Linecast(current_position, down_position, out hit))//Linecast함수는 정해진 두지점 사이를
                break;                                                      //선으로 연결하여 그 사이에 물체가 있는지 판단
            if (step == STEP.JUMP)
            {
                if (step_timer < Time.deltaTime * 3.0f)//3프레임정도 시간이 지난 다음
                    break;
            }
            is_landed = true;
        } while (false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        next_step = STEP.RUN;//무조건 달려나감
        StartCoroutine(speedcontrol());
    }
    IEnumerator speedcontrol()
    {
        while (true)
        {
            SPEED_MAX = 5.0f;
            yield return new WaitForSecondsRealtime(15.0f);
            SPEED_MAX = 6.0f;
            yield return new WaitForSecondsRealtime(15.0f);
            SPEED_MAX = 7.0f;
            yield return new WaitForSecondsRealtime(15.0f);
            SPEED_MAX = 9.0f;
            yield return new WaitForSecondsRealtime(15.0f);
            SPEED_MAX = 8.0f;
            yield return new WaitForSecondsRealtime(15.0f);
        }
       

    }
    void OnGUI()
    {
        GUI.Label(new Rect(81, Screen.height - 40, 128, 32), time.ToString());
        GUI.Label(new Rect(40, Screen.height - 40, 128, 32), SPEED_MAX.ToString());

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(new Vector3(0.0f, 0.0f, 3.0f * Time.deltaTime));
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        CheckLanded();
        //구멍 함수 때문에 추가
        switch (step)
        {
            case STEP.RUN:
            case STEP.JUMP:
                if (transform.position.y < FAIL_LIMIT)
                    next_step = STEP.MISS;
                break;
        }
        step_timer += Time.deltaTime;
        //여기까지 추가

        //step_timer += Time.deltaTime;

        if(next_step == STEP.NONE)
        {
            switch (step)//현재 상태
            {
                case STEP.RUN://달리는 중
                    if (!is_landed)
                    {
                    }
                    else if (Input.GetMouseButtonDown(0))//착지했을 경우
                        next_step = STEP.JUMP;//마우스 왼쪽 버튼 점프
                    break;
                case STEP.JUMP://점프중이면
                    if (is_landed)//착지했을때
                        next_step = STEP.RUN;//달리기
                    break;
            }
        }
        while(next_step != STEP.NONE)
        {
            step = next_step;
            next_step = STEP.NONE;

            switch (step)
            {
                case STEP.JUMP:
                    velocity.y = Mathf.Sqrt(2.0f * 9.8f * JUMP_HEIGHT_MAX);//수직속도
                    is_key_released = false;
                    break;
            }
            step_timer = 0.0f;//점프하면 스텝 타이머를 0으로 초기화
        }
        switch (step)
        {
            case STEP.RUN:
                velocity.x += player_control.ACCELERATION * Time.deltaTime;//acceleration현재속도 가속시켜준다
                if (Mathf.Abs(velocity.x) > player_control.SPEED_MAX)

                    velocity.x = player_control.SPEED_MAX;
                break;

            case STEP.JUMP:
                do
                {
                    if (!Input.GetMouseButtonUp(0))
                        break;
                    if (is_key_released)
                        break;
                    if (velocity.y <= 0.0f)//하강
                        break;

                    velocity.y *= JUMP_POWER_REDUCE;
                    is_key_released = true;
                } while (false);
                break;

            case STEP.MISS:
                velocity.x -= player_control.ACCELERATION * Time.deltaTime;
                if(velocity.x < 0.0f)
                {
                    velocity.x = 0.0f;
                    Application.Quit();
                }
                break;
        }
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
