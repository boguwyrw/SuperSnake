using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
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
