using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemana : MonoBehaviour
{
    public GameObject menuSet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //서브 메뉴
        if (Input.GetButtonDown("Cancel"))
            if(menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);

    }
    
}
