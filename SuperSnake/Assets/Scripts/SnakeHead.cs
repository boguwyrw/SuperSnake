using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{

    [SerializeField]
    private GameObject snakeBody;
    private List<GameObject> snake = new List<GameObject>();
    private float distance;
    private float snakeSpeed;
    private int numberOfApples;
    private int numberOfLives;
    [SerializeField]
    private Text numberOfApplesText;
    [SerializeField]
    private Text snakeLivesText;
    private Vector3 snakeStartPosition;
    private Quaternion snakeStartRotation;

    private void Awake()
    {
        snake.Add(gameObject);
        distance = 0.0f;
        snakeSpeed = 4.0f;
        numberOfApples = 0;
        numberOfLives = 4;
        ApplesCounting();
        SnakeLives();
        snakeStartPosition = transform.position;
        snakeStartRotation = transform.rotation;
    }

    private void Update()
    {
        SnakeMovement();
        SnakeSpeedsUp();
        ApplesCounting();
        SnakeLives();
        GameOver();
    }

    private void SnakeMovement()
    {
        transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);

        if (snake.Count > 1)
        {
            for (int i = 0; i < snake.Count - 1; i++)
            {
                distance = Vector3.Distance(snake[i].transform.position, snake[i + 1].transform.position);
                if (distance >= 1.0f)
                {
                    snake[i + 1].transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
                }
                else
                {
                    snake[i + 1].transform.Translate(Vector3.zero);
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
        if (numberOfApples == 10)
        {
            snakeSpeed = 8.0f;
        }
        if (numberOfApples == 20)
        {
            snakeSpeed = 12.0f;
        }
    }

    private void ApplesCounting()
    {
        if (numberOfApples > 1)
        {
            numberOfApplesText.text = "Apples: " + numberOfApples.ToString();
        }
        else
        {
            numberOfApplesText.text = "Apple: " + numberOfApples.ToString();
        }
    }

    private void SnakeLives()
    {
        if (numberOfLives > 1)
        {
            snakeLivesText.text = "Lives: " + numberOfLives.ToString();
        }
        else
        {
            snakeLivesText.text = "Life: " + numberOfLives.ToString();
        }
    }

    private void GameOver()
    {
        if (numberOfLives == 0)
        {
            Time.timeScale = 0;
        }
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
            snake.Clear();
            transform.position = snakeStartPosition;
            transform.rotation = snakeStartRotation;
            snakeSpeed = 4.0f;
            numberOfLives--;
            numberOfApples = 0;
            snake.Add(gameObject);
        }
    }

    public int GetNumberOfApples()
    {
        return numberOfApples;
    }

    public void TurnRight()
    {
        transform.Rotate(new Vector3(0, 90, 0));
    }

    public void TurnLeft()
    {
        transform.Rotate(new Vector3(0, -90, 0));
    }

}
