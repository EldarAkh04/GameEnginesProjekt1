using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource CarSource;
    [SerializeField] AudioSource RainSource;
    public AudioClip BMusic;
    public AudioClip CSound;
    public AudioClip RSound;

    private void Start()
    {
        musicSource.clip = BMusic;
        musicSource.loop = true;
        musicSource.Play();

        CarSource.clip = CSound;
        CarSource.loop = true;
        CarSource.Play();

        RainSource.clip = RSound;
        RainSource.loop = true;
        RainSource.Play();
    }
}
