using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Button startButton = null;
    [SerializeField] private Button resumeButton = null;
    [SerializeField] private Button exitButton = null;
    [SerializeField] private Button nextLevelButton = null;
    [SerializeField] private Text informationText = null;
    [SerializeField] private GameObject apple = null;
    [SerializeField] private SnakeHead snakeHead = null;

    private int applesNumber;
    private int livesNumber;
    private int winerPoints;
    private int openLevel;

    private void Awake()
    {
        nextLevelButton.transform.position = new Vector3(0.5f * Screen.width, 0.32f * Screen.height, 0.0f);
        nextLevelButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        applesNumber = 0;
        livesNumber = 4;
        winerPoints = 30;
        openLevel = 1;

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (transform.childCount == 0 && applesNumber < winerPoints-1)
        {
            float positionX = Random.Range(-16.5f, 16.5f);
            float positionZ = Random.Range(-16.5f, 16.5f);
            GameObject appleClone = Instantiate(apple, new Vector3(positionX, 0.5f, positionZ), transform.rotation);
            appleClone.transform.parent = gameObject.transform;
        }

        applesNumber = snakeHead.GetNumberOfApples();
        livesNumber = SnakeHead.numberOfLives;
        if (applesNumber == winerPoints)
        {
            informationText.text = "GRATULACJE!!!";

            string sceneName = SceneManager.GetActiveScene().name;

            switch(sceneName)
            {
                case "Level_1":
                    openLevel = 2;
                    if (PlayerPrefs.HasKey("Levels"))
                    {
                        if(PlayerPrefs.GetInt("Levels") < openLevel)
                            PlayerPrefs.SetInt("Levels", openLevel);
                    }
                    else
                        PlayerPrefs.SetInt("Levels", openLevel);
                    break;
                case "Level_2":
                    openLevel = 3;
                    PlayerPrefs.SetInt("Levels", openLevel);
                    break;
                case "Level_3":
                    openLevel = 3;
                    PlayerPrefs.SetInt("Levels", openLevel);
                    break;
            }

            if(!sceneName.Equals("Level_3"))
                nextLevelButton.gameObject.SetActive(true);
            else
                exitButton.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        if (livesNumber <= 0)
        {
            informationText.text = "Oooo! Przegrałeś";
            exitButton.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public int GetNumberOfChildren()
    {
        return transform.childCount;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LoadLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        resumeButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
