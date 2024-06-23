using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;



    private AudioSource bgmSource;
    private AudioSource sfxSource;

    // References to the UI sliders
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource components from the child objects
            bgmSource = transform.Find("BGM").GetComponent<AudioSource>();
            sfxSource = transform.Find("SFX").GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize slider values
        if (bgmSlider != null)
        {
            bgmSlider.value = GetBGMVolume();
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = GetSFXVolume();
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    public void PauseBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Pause();
        }
    }

    public void ResumeBGM()
    {
        if (bgmSource.time > 0)
        {
            bgmSource.UnPause();
        }
        else
        {
            bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip newBGM)
    {
        bgmSource.Stop();
        bgmSource.clip = newBGM;
        bgmSource.Play();
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public float GetBGMVolume()
    {
        return bgmSource.volume;
    }

    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

  
}
