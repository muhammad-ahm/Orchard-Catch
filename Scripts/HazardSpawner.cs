using UnityEngine;

// v4 change: full difficulty curve, using a fixed table of 7 tiers,
// stepping up every 50 score. Each tier controls THREE things at
// once: how often apples spawn, how fast bad apples fall, and how
// fast good apples fall (which now DOES increase, just later and
// slower than bad apples).
//
// Tier:                0     1     2     3     4     5     6
// Score threshold:      0    50   100   150   200   250   300
// Spawn interval:     1.6  1.35   1.1  0.85   0.6  0.35   0.2
// Bad apple speed:      1x    2x    3x    4x    5x    6x    7x
// Good apple speed:     1x    1x    1x    2x    2x    2x    3x

public class HazardSpawner : MonoBehaviour
{
    public GameObject goodApplePrefab;
    public GameObject badApplePrefab;

    public float spawnWidth = 4f;   // how far left/right hazards can spawn
    public float spawnHeight = 6f;  // y position considered "top of screen"

    [Header("Base fall speed - this is what '1x' means in the table")]
    public float baseFallSpeed = 3f;

    // the table itself - index 0 is the starting tier, index 6 is the
    // hardest/final tier (stays at these values once reached, doesn't
    // go further even if score keeps climbing)
    private readonly float[] spawnIntervals   = { 1.6f, 1.35f, 1.1f, 0.85f, 0.6f, 0.35f, 0.2f };
    private readonly float[]   hazardMultiplier = { 1,    1.5f,     2,    2.5f,     3,    3.5f,     4    };
    private readonly float[]   catchMultiplier  = { 1,    1,     1,    2,     2,    2,     3    };
    private const int SCORE_STEP = 50; // one tier every 50 score

    private int currentTier = 0;
    private float currentGoodFallSpeed;
    private float currentBadFallSpeed;

    void Start()
    {
        ApplyTier(0);
        InvokeRepeating(nameof(SpawnHazard), 1f, spawnIntervals[currentTier]);
    }

    void SpawnHazard()
    {
        bool isGood = Random.value < 0.5f; // 50/50 chance
        GameObject prefabToSpawn = isGood ? goodApplePrefab : badApplePrefab;

        float randomX = Random.Range(-spawnWidth, spawnWidth);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);

        GameObject spawned = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        Hazard hazard = spawned.GetComponent<Hazard>();
        hazard.fallSpeed = isGood ? currentGoodFallSpeed : currentBadFallSpeed;
    }

    // GameManager calls this with the tier number the current score
    // maps to (score / 50, capped to the table's last index). Only
    // actually changes anything if the tier is genuinely new.
    public void SetTier(int tier)
    {
        int clampedTier = Mathf.Min(tier, spawnIntervals.Length - 1);
        if (clampedTier == currentTier) return; // no change, nothing to do

        currentTier = clampedTier;
        ApplyTier(currentTier);

        // spawn interval changed, so the repeating timer needs restarting
        // with the new interval
        CancelInvoke(nameof(SpawnHazard));
        InvokeRepeating(nameof(SpawnHazard), 0f, spawnIntervals[currentTier]);
    }

    void ApplyTier(int tier)
    {
        currentGoodFallSpeed = baseFallSpeed * catchMultiplier[tier];
        currentBadFallSpeed = baseFallSpeed * hazardMultiplier[tier];
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnHazard));
    }
}
