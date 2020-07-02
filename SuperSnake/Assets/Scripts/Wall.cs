using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private bool snakeBodyCollide;
    private GameController gameController;
    private int numberOfChildren;

    private void Awake()
    {
        snakeBodyCollide = false;
        gameController = FindObjectOfType<GameController>();
        numberOfChildren = 0;
    }

    private void Update()
    {
        numberOfChildren = gameController.GetNumberOfChildren();
        if (numberOfChildren == 0)
        {
            snakeBodyCollide = false;
        }

        Debug.Log(snakeBodyCollide);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnakeBody"))
        {
            snakeBodyCollide = true;
        }
        else
        {
            snakeBodyCollide = false;
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SnakeBody"))
        {
            Debug.Log("Mam CIE!");
            snakeBodyCollide = true;
        }
        /*
        else
        {
            //snakeBodyCollide = false;
        }
        */
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
        }
    }
    */
    public bool GetSnakeBodyCollide()
    {
        return snakeBodyCollide;
    }

}
