using UnityEngine;
using UnityEngine.UI; // for the heart Images
using TMPro;

// v4 change: difficulty is now a tier lookup (score / 50, capped at
// tier 6) instead of a single incrementing threshold. Every catch
// recalculates which tier the current score falls into and tells the
// spawner - the spawner ignores the call if the tier hasn't actually
// changed, so this is safe to call every single catch without extra
// checks here.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText;
    public Image[] lifeIcons;
    public GameObject gameOverPanel;
    public HazardSpawner spawner;

    [Header("Sound Effects")]
    public AudioClip catchSound;
    public AudioClip hitSound;
    public AudioClip gameOverSound;
    public AudioClip buttonClickSound;

    private const int SCORE_STEP = 50; // must match HazardSpawner's SCORE_STEP

    private int score = 0;
    private int lives = 3;
    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateScoreUI();
    }

    public void CollectGood()
    {
        if (isGameOver) return;

        score += 3;
        UpdateScoreUI();
        UpdateDifficultyTier();
        AudioManager.Instance.PlaySFX(catchSound);
    }

    public void HitBad()
    {
        if (isGameOver) return;

        lives -= 1;
        UpdateLivesUI();
        AudioManager.Instance.PlaySFX(hitSound);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateDifficultyTier()
    {
        int tier = score / SCORE_STEP; // integer division: 0-49 -> 0, 50-99 -> 1, etc.
        spawner.SetTier(tier); // spawner itself ignores this if the tier didn't change
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < lives;
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        spawner.StopSpawning();
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlaySFX(gameOverSound);
    }

    public void Restart()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    public void BackToMenu()
    {
        AudioManager.Instance.PlaySFX(buttonClickSound);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
