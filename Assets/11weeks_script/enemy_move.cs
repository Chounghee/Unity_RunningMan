using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float rot_angle = 15.0f;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //float current_angle = rot_angle * Time.deltaTime;//1초에 15도 회전
        //this.transform.RotateAround(Vector3.zero, Vector3.up, current_angle);  
        MoveToTarget();
    }
    void MoveToTarget()
    {
        agent.SetDestination(target.transform.position);
    }
}
