using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Button startButton = null;
    [SerializeField] private Button exitButton = null;
    [SerializeField] private Button nextLevelButton = null;
    [SerializeField] private Text informationText = null;
    [SerializeField] private GameObject apple = null;
    [SerializeField] private SnakeHead snakeHead = null;

    private int applesNumber;
    private int livesNumber;
    private int winerPoints;

    private void Awake()
    {
        nextLevelButton.transform.position = new Vector3(0.5f * Screen.width, 0.4f * Screen.height, 0.0f);
        nextLevelButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        applesNumber = 0;
        livesNumber = 4;
        winerPoints = 30;

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
            nextLevelButton.gameObject.SetActive(true);
            
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

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
