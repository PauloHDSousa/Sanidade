using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbajourObject : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    Color lightOnColor;
    [SerializeField]
    Color lightOffColor;
    [SerializeField]
    AudioClip click_sound;

    bool isOn = true;

    Camera main_camera;
    AudioSource audioSource;
    private void Start()
    {
        main_camera = Camera.main.GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Switch()
    {
        audioSource.PlayOneShot(click_sound);

        if (isOn)
        {
            main_camera.backgroundColor = lightOffColor;
            isOn = false;
        }
        else
        {
            main_camera.backgroundColor = lightOnColor;
            isOn = true;
        }
    }

}
