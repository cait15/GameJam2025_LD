using System;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _rotationSpeed = 360f;

    private Rigidbody _rigidbody;
    private Transform _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (_player == null)
        {
            Debug.LogError("Player not found in the scene. Ensure the player has the 'Player' tag.");
        }

        // Freeze unnecessary Rigidbody axes
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }

    private void FixedUpdate()
    {
        if (_player == null)
        {
            return;
        }

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 directionToPlayer = (_player.position - transform.position).normalized;

        // Rotate towards the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        // Move towards the player using velocity
        _rigidbody.velocity = transform.forward * _speed;
    }
}
