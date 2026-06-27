using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(clip);
    }
}
