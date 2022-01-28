using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int stage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()
    {
        Debug.Log("새게임");
        SceneManager.LoadScene(2);
    }
    
    public void OnClickContinue()
    {
        Debug.Log("계속하기");
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
