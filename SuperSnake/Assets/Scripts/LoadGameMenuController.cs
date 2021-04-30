using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameMenuController : MonoBehaviour
{
    [SerializeField] private List<Button> levelsButtons = null;

    private int availableLevels;

    private void Awake()
    {
        availableLevels = 1;

        if (PlayerPrefs.HasKey("Levels"))
        {
            availableLevels = PlayerPrefs.GetInt("Levels");
            
            for (int i = 0; i < availableLevels; i++)
            {
                levelsButtons[i].interactable = true;
            }
        }
    }

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
