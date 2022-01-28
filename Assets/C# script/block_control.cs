using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_control : MonoBehaviour//불필요한 블록 지우기
{
    public map_creator map_script = null;
   
    void Start()
    {
        map_script = GameObject.Find("block_root").GetComponent<map_creator>();
    }

    
    void Update()
    {
        if (map_script.IsGone(gameObject))//isgone사용해서
            GameObject.Destroy(gameObject);
    }
}
