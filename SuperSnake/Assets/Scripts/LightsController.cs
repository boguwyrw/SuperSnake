using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    [SerializeField] private Light rightLight;
    [SerializeField] private Light leftLight;

    private void Start()
    {
        rightLight.gameObject.SetActive(true);
        leftLight.gameObject.SetActive(true);

        rightLight.transform.localPosition = new Vector3(0, 0, -0.25f);
        leftLight.transform.localPosition = new Vector3(0, 0, -0.25f);

        rightLight.range = 18;
        leftLight.range = 18;

        rightLight.spotAngle = 95;
        leftLight.spotAngle = 95;

        rightLight.intensity = 10;
        leftLight.intensity = 10;
    }
}
