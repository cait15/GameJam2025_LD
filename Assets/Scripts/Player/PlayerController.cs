using UnityEngine;
using System.Collections;
using System.Collections.Generic;  

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] private GameObject slash;
    private float attackDelay = 0.3f;
    private bool attackBlocked;
    private float cooldownTime = 0.5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            if (!attackBlocked)
            {
                Attack();
            }
        }
    }

    private void Attack(){
         slash.SetActive(true);
         attackBlocked = true; // Block attacks during animation
         StartCoroutine(DisableSlashAfterDelay());
    }

    private IEnumerator DisableSlashAfterDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        slash.SetActive(false);
        yield return new WaitForSeconds(cooldownTime); // Cooldown after attack animation
        attackBlocked = false;
    }

}
