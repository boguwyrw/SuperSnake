using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeGameController : MonoBehaviour
{
    [SerializeField] private Button startButton = null;
    [SerializeField] private Text informationText = null;
    [SerializeField] private GameObject apple = null;
    [SerializeField] private SnakeHead snakeHead = null;

    private int applesNumber;
    private int livesNumber;

    private void Awake()
    {
        applesNumber = 0;
        livesNumber = 4;

        Time.timeScale = 0;
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

        if (livesNumber <= 0)
        {
            if (applesNumber != 1)
                informationText.text = "Twój rekord to: " + applesNumber.ToString() + " jabłek";
            else if (applesNumber == 1)
                informationText.text = "Twój rekord to: " + applesNumber.ToString() + " jabłko";

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
}
