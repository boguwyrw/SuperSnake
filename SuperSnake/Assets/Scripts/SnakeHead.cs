using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    [SerializeField]
    private GameObject snakeBody;
    private List<GameObject> snake = new List<GameObject>();
    private float distance;
    private float snakeSpeed;

    private void Awake()
    {
        snake.Add(gameObject);
        distance = 0.0f;
        snakeSpeed = 4.0f;
    }

    private void Update()
    {
        SnakeMovement();
    }

    private void SnakeMovement()
    {
        transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);

        if (snake.Count > 1)
        {
            for (int i = 1; i < snake.Count; i++)
            {
                distance = Vector3.Distance(snake[i].transform.position, snake[i - 1].transform.position);
                if (distance >= 1.0f)
                {
                    snake[i].transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
                }
                else
                {
                    snake[i].transform.Translate(Vector3.zero);
                }

                snake[i].transform.LookAt(snake[i - 1].transform);
            }
        }
    }

    private void SnakeGrow()
    {
        GameObject partOfSnakeBody = Instantiate(snakeBody, (snake[snake.Count - 1].transform.position - transform.forward), transform.rotation);
        snake.Add(partOfSnakeBody);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            SnakeGrow();
        }
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
