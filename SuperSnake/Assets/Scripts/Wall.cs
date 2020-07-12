using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private SnakeHead snakeHead;

    private void Awake()
    {
        snakeHead = FindObjectOfType<SnakeHead>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnakeBody"))
        {
            snakeHead.SnakeRestart();
        }
    }

}
