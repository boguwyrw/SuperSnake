using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseChallengeGameController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ChallengeGameController challengeGameController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
            challengeGameController.PauseGame();
    }
}
