using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseDarkGameController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private DarkGameController darkGameController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
            darkGameController.PauseGame();
    }
}
