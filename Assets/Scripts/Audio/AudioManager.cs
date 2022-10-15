using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource.loop = true;
        audioSource.Play();
    }
}
