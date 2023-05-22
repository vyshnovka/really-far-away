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
