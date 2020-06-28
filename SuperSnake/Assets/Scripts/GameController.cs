using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button nextLevelButton;
    [SerializeField]
    private Text numberOfApplesText;
    [SerializeField]
    private Text snakeLivesText;
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject apple;

    private SnakeHead snakeHead;
    private int applesNumber;

    private void Awake()
    {
        startButton.transform.position = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0.0f);
        rightButton.transform.position = new Vector3(0.88f * Screen.width, 0.12f * Screen.height, 0.0f);
        leftButton.transform.position = new Vector3(0.12f * Screen.width, 0.12f * Screen.height, 0.0f);
        nextLevelButton.transform.position = new Vector3(0.5f * Screen.width, 0.4f * Screen.height, 0.0f);
        numberOfApplesText.transform.position = new Vector3(0.1f * Screen.width, 0.9f * Screen.height, 0.0f);
        snakeLivesText.transform.position = new Vector3(0.9f * Screen.width, 0.9f * Screen.height, 0.0f);
        informationText.transform.position = new Vector3(0.5f * Screen.width, 0.6f * Screen.height, 0.0f);

        nextLevelButton.gameObject.SetActive(false);

        snakeHead = FindObjectOfType<SnakeHead>();
        applesNumber = 0;

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (transform.childCount == 0)
        {
            float positionX = Random.Range(-16.5f, 16.5f);
            float positionZ = Random.Range(-16.5f, 16.5f);
            GameObject appleClone = Instantiate(apple, new Vector3(positionX, 0.5f, positionZ), transform.rotation);
            appleClone.transform.parent = gameObject.transform;
        }

        applesNumber = snakeHead.GetNumberOfApples();
        if (applesNumber >= 30)
        {
            informationText.text = "GRATULACJE!!!";
            nextLevelButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

}
