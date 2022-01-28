﻿using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scene_transition : MonoBehaviour
{
    public GameObject prefab = null;
    public Texture2D icon = null;
    private int unito_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject game_object = GameObject.Instantiate(this.prefab) as GameObject;
            game_object.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 1.0f, Random.Range(-2.0f, 2.0f));
            unito_count++;  
        }
        if(unito_count > 10)
        {
            SceneManager.LoadScene("scene1", LoadSceneMode.Single);
        }
               
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, Screen.height - 64, 64, 64), icon);
        GUI.Label(new Rect(81, Screen.height - 40, 128, 32), unito_count.ToString());
    }
}
