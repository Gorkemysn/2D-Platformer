using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen;
    // Start is called before the first frame update
    public void StartGame()
    {
        Invoke("ExecuteLoad", 1.5f);
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Invoke("ExecuteQuit", 1.5f);
    }

    private void ExecuteLoad()
    {
        SceneManager.LoadScene(1);
    }

    private void ExecuteQuit()
    {
        Application.Quit();
    }
}
