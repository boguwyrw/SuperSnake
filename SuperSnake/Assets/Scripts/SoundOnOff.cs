using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundOnOff : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
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
        }
        else
        {
            audioSource.volume = audioSourceStartVolume;
            soundImage.sprite = soundOn;
        }
    }
}
