using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeMenuController : MonoBehaviour
{
    public void StartGameBestOf()
    {
        SceneManager.LoadScene("BestOf");
    }

    public void StartGameDark()
    {
        SceneManager.LoadScene("Dark");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
