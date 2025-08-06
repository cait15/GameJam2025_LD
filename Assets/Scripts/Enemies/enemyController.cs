using UnityEngine;
using UnityEngine.Video;

public class enemyController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            Destroy(gameObject); // Destroy the enemy when it collides with the attack object
        }
    }
}
