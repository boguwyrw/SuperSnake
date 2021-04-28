using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void LoadGameLevel()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadChallengeGame()
    {
        SceneManager.LoadScene("Challenge");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
