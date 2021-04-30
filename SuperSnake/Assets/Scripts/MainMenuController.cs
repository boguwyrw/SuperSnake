using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void StartGameLevel()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadChallenges()
    {
        SceneManager.LoadScene("ChallengeMenu");
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene("LoadGameMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
