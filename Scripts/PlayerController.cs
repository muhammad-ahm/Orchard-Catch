using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;      // how fast the player moves
    public float screenHalfWidth = 4f; // how far left/right the player can go (tune in Inspector)

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * moveSpeed * Time.deltaTime;

        // Step 3: clamp so the player can't go off-screen
        pos.x = Mathf.Clamp(pos.x, -screenHalfWidth, screenHalfWidth);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Hazard hazard = other.GetComponent<Hazard>();
        if (hazard == null) return;

        if (hazard.isGood)
        {
            GameManager.Instance.CollectGood();
        }
        else
        {
            GameManager.Instance.HitBad();
        }

        Destroy(other.gameObject); // remove the apple either way, it's been "consumed"
    }
}
