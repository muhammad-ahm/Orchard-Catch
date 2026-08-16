using UnityEngine;
using UnityEngine.SceneManagement;

// Attach this to an empty GameObject in your Main Menu scene.

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;        // the panel holding Start/Options/Instructions/Credits buttons
    public GameObject optionsPanel;
    public GameObject instructionsPanel;
    public GameObject creditsPanel;
    public AudioClip buttonClickSound;

    // hooked to the Start button's OnClick in the Inspector
    public void OnStartClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        SceneManager.LoadScene("Game"); // must match your Game scene's exact name, case-sensitive
    }

    // hooked to the Options button's OnClick in the Inspector
    public void OnOptionsClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    // hooked to the Instructions button's OnClick in the Inspector
    public void OnInstructionsClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    // hooked to the Credits/License button's OnClick in the Inspector
    public void OnCreditsClicked()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
