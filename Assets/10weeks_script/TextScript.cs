using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text ScriptTxt;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;

        }
        if (count > 5)
        {
            ScriptTxt.text = "Press 'R' to continue";
        }
    }
}
