using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SoundOnOff : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundController soundController;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;

    private float audioSourceStartVolume;
    private Image soundImage;

    private void Start()
    {
        audioSourceStartVolume = audioSource.volume;
        soundImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource.volume > 0.0f)
        {
            audioSource.volume = 0.0f;
            soundImage.sprite = soundOff;
            if (!SceneManager.GetActiveScene().name.Equals("Dark"))
                soundController.soundIsMute = true;
        }
        else
        {
            audioSource.volume = audioSourceStartVolume;
            soundImage.sprite = soundOn;
            if (!SceneManager.GetActiveScene().name.Equals("Dark"))
                soundController.soundIsMute = false;
        }
    }
}
