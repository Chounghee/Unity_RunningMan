using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()
    {
        Debug.Log("다음");
        SceneManager.LoadScene(2);
    }
    public void OnClickBack()
    {
        Debug.Log("뒤로가기");
        SceneManager.LoadScene(0);
    }
}
