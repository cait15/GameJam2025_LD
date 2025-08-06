using UnityEngine;

public class Boss1Controller : MonoBehaviour
{

   [SerializeField] private bossHealthBarUI bosshealthUi;
   
   public float damage = 10f; // Damage dealt by the boss

    [SerializeField] private GameObject savingPaul;

   public float _health = 100f;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boss hit by attack!");
        if (other.CompareTag("Attack"))
        {
            _health -= damage;
           bosshealthUi.UpdateHealthBar(this); // Update the health bar UI with the current health percentage
            Debug.Log("Boss Health: " + _health);
        }
    }

    private void Update()
    {
        if (_health <= 0f)
        {
            savingPaul.SetActive(true); // Show the saving Paul object when the boss is defeated
            Destroy(gameObject); 
        }
    }

}
