using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool madeFirstChange;
    private bool madeSecondChange;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        madeFirstChange = false;
        madeSecondChange = false;
    }

    private void Update()
    {
        if (SnakeHead.snakeSpeed == 8.0f && !madeFirstChange)
            SnakeGoesFast();
        else if (SnakeHead.snakeSpeed == 12.0f && !madeSecondChange)
            SnakeGoesFaster();
        else if (SnakeHead.snakeSpeed == 4.0f)
            SnakeGoesNormal();
    }

    private void SnakeGoesNormal()
    {
        if (madeFirstChange || madeSecondChange)
        {
            audioSource.volume = 0.0f;
            audioSource.pitch = 1.0f;
            StartCoroutine(VolumeUp());
            madeFirstChange = false;
            madeSecondChange = false;
        }
    }

    private void SnakeGoesFast()
    {
        audioSource.volume = 0.0f;
        audioSource.pitch = 1.12f;
        StartCoroutine(VolumeUp());
        madeFirstChange = true;
    }

    private void SnakeGoesFaster()
    {
        audioSource.volume = 0.0f;
        audioSource.pitch = 1.24f;
        StartCoroutine(VolumeUp());
        madeSecondChange = true;
    }

    private IEnumerator VolumeUp()
    {
        yield return new WaitForSeconds(0.1f);
        audioSource.volume = 0.8f;
    }
}
