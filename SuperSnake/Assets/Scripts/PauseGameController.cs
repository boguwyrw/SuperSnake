using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGameController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameController gameController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
            gameController.PauseGame();
    }
}
