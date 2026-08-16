using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer")]
    public AudioMixer mainMixer;   // drag your MainMixer asset here

    [Header("Audio Sources")]
    public AudioSource musicSource; // one dedicated source that loops music
    public AudioSource sfxSource;   // one shared source for one-shot sound effects

    [Header("Music")]
    public AudioClip backgroundMusic;

    private bool isMuted = false;
    private float lastMusicVolume = 0.75f;
    private float lastSFXVolume = 0.75f;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        lastMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        lastSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;

        SetMusicVolume(lastMusicVolume);
        SetSFXVolume(lastSFXVolume);
        ApplyMuteState();

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float value)
    {
        lastMusicVolume = value;
        mainMixer.SetFloat("MusicVolume", LinearToDecibel(value));
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        lastSFXVolume = value;
        mainMixer.SetFloat("SFXVolume", LinearToDecibel(value));
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        ApplyMuteState();
    }

    void ApplyMuteState()
    {
        if (isMuted)
        {
            mainMixer.SetFloat("MusicVolume", -80f); // -80dB is effectively silent
            mainMixer.SetFloat("SFXVolume", -80f);
        }
        else
        {
            mainMixer.SetFloat("MusicVolume", LinearToDecibel(lastMusicVolume));
            mainMixer.SetFloat("SFXVolume", LinearToDecibel(lastSFXVolume));
        }
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    float LinearToDecibel(float linear)
    {
        if (linear <= 0.0001f) return -80f;
        return Mathf.Log10(linear) * 20f;
    }
}
