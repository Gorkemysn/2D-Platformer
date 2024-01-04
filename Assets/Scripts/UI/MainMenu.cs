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
        SceneManager.LoadScene("Level_1");
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
