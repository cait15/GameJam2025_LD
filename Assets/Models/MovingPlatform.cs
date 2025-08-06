using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right;
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    public float tolerance = 0.1f;

    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveStep = moveSpeed * Time.deltaTime;
        Vector3 targetOffset = moveDirection.normalized * moveDistance;
        Vector3 targetPosition = startPosition + (movingForward ? targetOffset : -targetOffset);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveStep);

        if (Vector3.Distance(transform.position, targetPosition) < tolerance)
        {
            movingForward = !movingForward;
        }
    }
}
