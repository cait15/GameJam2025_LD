using UnityEngine;

public class PoofPlatform : MonoBehaviour
{
    public float Delay = 2.0f; // Time before destruction
    public string triggeringTag = "Player"; // Only interacts with the player
    public float flashInterval = 0.2f; // Interval for flashing

    private bool triggered = false;
    private Renderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!triggered && collision.collider.CompareTag(triggeringTag))
        {
            triggered = true;
            StartCoroutine(FlashAndDestroy());
        }
    }

    private System.Collections.IEnumerator FlashAndDestroy()
    {
        float elapsedTime = 0f;
        while (elapsedTime < Delay)
        {
            platformRenderer.enabled = !platformRenderer.enabled; // Toggle visibility
            yield return new WaitForSeconds(flashInterval);
            elapsedTime += flashInterval;
        }

        Destroy(gameObject);
    }
}

