using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeGameController : MonoBehaviour
{
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button resumeButton = null;
    [SerializeField] private Button exitButton = null;
    [SerializeField] private Text informationText = null;
    [SerializeField] private Text bestScoreText = null;
    [SerializeField] private GameObject apple = null;
    [SerializeField] private SnakeHead snakeHead = null;

    private int applesNumber;
    private int maxApplesNumber;
    private int livesNumber;

    private void Awake()
    {
        applesNumber = 0;
        livesNumber = 4;
        maxApplesNumber = 0;

        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Time.timeScale = 0;

        PlayerBestScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (transform.childCount == 0)
        {
            float positionX = Random.Range(-16.5f, 16.5f);
            float positionZ = Random.Range(-16.5f, 16.5f);
            GameObject appleClone = Instantiate(apple, new Vector3(positionX, 0.5f, positionZ), transform.rotation);
            appleClone.transform.parent = gameObject.transform;
        }

        applesNumber = snakeHead.GetNumberOfApples();
        livesNumber = SnakeHead.numberOfLives;

        PlayerBestScore();

        if (livesNumber <= 0)
        {
            if (applesNumber != 1)
                informationText.text = "Twój rekord to: " + maxApplesNumber.ToString() + " jabłek";
            else if (applesNumber == 1)
                informationText.text = "Twój rekord to: " + maxApplesNumber.ToString() + " jabłko";

            exitButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void PlayerBestScore()
    {
        if (PlayerPrefs.HasKey("MaxApplesNumber"))
            maxApplesNumber = PlayerPrefs.GetInt("MaxApplesNumber");

        if (maxApplesNumber < applesNumber)
            maxApplesNumber = applesNumber;

        bestScoreText.text = "Najlepszy\nwynik: " + maxApplesNumber.ToString();
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
