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
    [SerializeField]
    private GameObject apple;

    private void Awake()
    {
        rightButton.transform.position = new Vector3(0.9f * Screen.width, 0.1f * Screen.height, 0.0f);
        leftButton.transform.position = new Vector3(0.1f * Screen.width, 0.1f * Screen.height, 0.0f);
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            float positionX = Random.Range(-16.5f, 16.5f);
            float positionZ = Random.Range(-16.5f, 16.5f);
            GameObject appleClone = Instantiate(apple, new Vector3(positionX, 0.5f, positionZ), transform.rotation);
            appleClone.transform.parent = gameObject.transform;
        }
    }
}
