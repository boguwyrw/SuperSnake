using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnLeftController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private SnakeHead snakeHead;

    public void OnPointerDown(PointerEventData eventData)
    {
        snakeHead.TurnLeft();
    }
}
