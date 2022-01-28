using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear_load_coin : MonoBehaviour
{
    //public Text coinText;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        GameObject.Find("Player").GetComponent<playercoin>();
        //coinText.text = itemCount + "원";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
