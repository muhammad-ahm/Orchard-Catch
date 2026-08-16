using UnityEngine;

public class ClosablePanel : MonoBehaviour
{
    public GameObject panelRoot;   // usually just drag in this same GameObject
    public GameObject mainPanel;   // drag in the Main Menu's button panel, so it reappears
    public AudioClip buttonClickSound;

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
