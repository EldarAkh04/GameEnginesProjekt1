using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource CarSource;
    public AudioClip BMusic;
    public AudioClip CSound;

    private void Start()
    {
        musicSource.clip = BMusic;
        musicSource.loop = true;
        musicSource.Play();

        CarSource.clip = CSound;
        CarSource.loop = true;
        CarSource.Play();
    }
}
