using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button muteButton;
    public GameObject panelRoot; // the panel GameObject itself, to show/hide
    public GameObject mainPanel; // drag in the Main Menu's button panel, so it reappears
    public AudioClip buttonClickSound;

    void OnEnable()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
    }

    void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.RemoveListener(AudioManager.Instance.SetSFXVolume);
    }

    public void OffMuteClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
    }

    public void OnMuteClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        AudioManager.Instance.ToggleMute();
    }

    public void Close()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        panelRoot.SetActive(false);
        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
        }
    }
}
