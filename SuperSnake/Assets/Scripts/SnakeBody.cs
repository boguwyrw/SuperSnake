using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    private SnakeHead snakeHead;
    private int applesNumber;

    private void Awake()
    {
        snakeHead = FindObjectOfType<SnakeHead>();
        applesNumber = 0;
    }

    private void Update()
    {
        applesNumber = snakeHead.GetNumberOfApples();
        if (applesNumber == 0)
        {
            Destroy(gameObject);
        }
    }

}
