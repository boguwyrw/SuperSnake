using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameMenuController : MonoBehaviour
{
    public void StartGameLevel_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void StartGameLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void StartGameLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
