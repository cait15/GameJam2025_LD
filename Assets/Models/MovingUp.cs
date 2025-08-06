using UnityEngine;

public class MovingUp : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movestep = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = startPosition + (movingUp ? Vector3.up : Vector3.down) * moveDistance;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movestep);

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            movingUp = !movingUp;
        }
    }
}
