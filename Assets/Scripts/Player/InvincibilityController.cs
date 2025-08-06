using System;
using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{

    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvinc(float invincDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincDuration)
    {
        _healthController.tempImmunityActive = true;
        yield return new WaitForSeconds(invincDuration);
        _healthController.tempImmunityActive = false;
    }

}
