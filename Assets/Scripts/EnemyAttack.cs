using UnityEngine;

public class EnemyAtta : MonoBehaviour
{
    [SerializeField] private float _damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              //Debug.Log("trigger");
            HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();

            if (playerHealth != null)
            {
                //Debug.Log("Player hit by enemy attack!");
                playerHealth.TakeDamage(_damage);
                Destroy(this.gameObject); // Destroy the enemy attack object after dealing damage
            }
            else
            {
                Debug.LogWarning("No HealthController found on Player!");
            }
        }
    }
}
