using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button exitButton;

    private void Awake()
    {
        newGameButton.transform.position = new Vector3(0.5f * Screen.width, 0.6f * Screen.height, 0.0f);
        exitButton.transform.position = new Vector3(0.5f * Screen.width, 0.4f * Screen.height, 0.0f);
    }

    private void Update()
    {
        
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
