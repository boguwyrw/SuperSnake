using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button leftButton;

    private void Awake()
    {
        rightButton.transform.position = new Vector3(0.9f * Screen.width, 0.1f * Screen.height, 0.0f);
        leftButton.transform.position = new Vector3(0.1f * Screen.width, 0.1f * Screen.height, 0.0f);
    }

    private void Update()
    {
        
    }
}
