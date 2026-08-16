using UnityEngine;

// this object knows whether it's "good" (apple) or "bad" (rotten
// apple), and how fast to fall. isGood is set per-prefab in the
// Inspector. fallSpeed now gets overwritten at spawn time by
// HazardSpawner (see SpawnHazard()) so difficulty can affect bad
// apples individually - the Inspector value here just acts as a
// fallback/default if you test this prefab in isolation.

public class Hazard : MonoBehaviour
{
    public bool isGood = true;
    public float fallSpeed = 3f;
    public float bottomLimit = -5f; // y position considered "off screen"

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
