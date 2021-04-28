using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private SnakeHead snakeHead = null;
    private int numberOfHits = 0;

    private void Update()
    {
        if (snakeHead.GetNumberOfApples() == 1)
            numberOfHits = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnakeBody"))
        {
            numberOfHits++;
            if (numberOfHits == 1)
                snakeHead.SnakeRestart();
        }
    }
}
