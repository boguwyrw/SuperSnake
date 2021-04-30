using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{

    public static int numberOfLives = 4;
    public static float snakeSpeed = 4;
    [SerializeField] private GameObject snakeBody = null;
    private List<GameObject> snake = new List<GameObject>();
    private float distance;
    private int numberOfApples;
    [SerializeField] private Text numberOfApplesText = null;
    [SerializeField] private Text snakeLivesText = null;
    private Vector3 snakeStartPosition;
    private Quaternion snakeStartRotation;

    private void Awake()
    {
        snake.Add(gameObject);
        distance = 0.0f;
        numberOfApples = 0;
        ApplesCounting();
        SnakeLives();
        snakeStartPosition = transform.position;
        snakeStartRotation = transform.rotation;

        if (SceneManager.GetActiveScene().name.Equals("Dark"))
            snakeSpeed = 6.8f;
    }

    private void Update()
    {
        SnakeSpeedsUp();
        ApplesCounting();
        SnakeLives();
        GameOver();

        if (numberOfLives <= 0)
            numberOfLives = 0;
    }

    private void FixedUpdate()
    {
        SnakeMovement();
    }

    private void SnakeMovement()
    {
        transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        if (snake.Count > 1)
        {
            for (int i = 0; i < snake.Count - 1; i++)
            {
                distance = Vector3.Distance(snake[i].transform.position, snake[i + 1].transform.position);
                if (distance >= 0.99f)
                {
                    snake[i + 1].transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
                }

                snake[i + 1].transform.LookAt(snake[i].transform);
            }
        }
    }

    private void SnakeGrow()
    {
        GameObject partOfSnakeBody = Instantiate(snakeBody, (snake[snake.Count - 1].transform.position - transform.forward), transform.rotation);
        snake.Add(partOfSnakeBody);
    }

    private void SnakeSpeedsUp()
    {
        if(!SceneManager.GetActiveScene().name.Equals("Dark"))
        {
            if (numberOfApples == 10)
            {
                snakeSpeed = 8.0f;
            }

            if (numberOfApples == 20)
            {
                snakeSpeed = 12.0f;
            }
        }
    }

    private void ApplesCounting()
    {
        if (numberOfApples > 1)
        {
            numberOfApplesText.text = "Jabłka: " + numberOfApples.ToString();
        }
        else
        {
            numberOfApplesText.text = "Jabłko: " + numberOfApples.ToString();
        }
    }

    private void SnakeLives()
    {
        if (numberOfLives > 1)
        {
            snakeLivesText.text = "Życia: " + numberOfLives.ToString();
        }
        else
        {
            snakeLivesText.text = "Życie: " + numberOfLives.ToString();
        }
    }

    private void GameOver()
    {
        if (numberOfLives == 0)
        {
            Time.timeScale = 0;
        }
    }
    // metoda zostanie przekazana do Wall
    public void SnakeRestart()
    {
        if(numberOfApples > PlayerPrefs.GetInt("MaxApplesNumber") && SceneManager.GetActiveScene().name.Equals("BestOf"))
            PlayerPrefs.SetInt("MaxApplesNumber", numberOfApples);

        if (numberOfApples > PlayerPrefs.GetInt("MaxDarkApplesNumber") && SceneManager.GetActiveScene().name.Equals("Dark"))
            PlayerPrefs.SetInt("MaxDarkApplesNumber", numberOfApples);

        snake.Clear();
        transform.position = snakeStartPosition;
        transform.rotation = snakeStartRotation;
        if(SceneManager.GetActiveScene().name.Equals("Dark"))
            snakeSpeed = 6.8f;
        else
            snakeSpeed = 4.0f;
        numberOfLives--;
        numberOfApples = 0;
        snake.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            numberOfApples++;
            SnakeGrow();
        }
        
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("SnakeBody"))
        {
            SnakeRestart();
        }
    }

    public int GetNumberOfApples()
    {
        return numberOfApples;
    }

    public void TurnRight()
    {
        if (Time.timeScale == 1)
            transform.Rotate(new Vector3(0, 90, 0));
    }

    public void TurnLeft()
    {
        if (Time.timeScale == 1)
            transform.Rotate(new Vector3(0, -90, 0));
    }

    public void GameWasRestarted()
    {
        numberOfLives = 4;
    }
}
