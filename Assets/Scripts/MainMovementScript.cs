using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MainMovementScript : MonoBehaviour
{
    public enum MovementState
    {
        SideScrollerState,
        TopDownState
    }
    [Header("Movement Settings")]
    public MovementState currentMode = MovementState.SideScrollerState;
    public float movementSpeed = 5.0f;
    public float jumpFloat = 8;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    [Header("Dash Settings")]
    public float dashImpulse = 50f;
    public float dashCooldown = 0.5f;
    public float doubleTapThreshold = 0.5f;
    private float lastTapTimeLeft;
    private float lastTapTimeRight;
    private bool canDash = true;

    public float damage;

    [SerializeField] private GameObject slash;
    private float attackDelay = 0.3f;
    private bool attackBlocked;
    private float cooldownTime = 0.5f;
     public Animator animator;

     [SerializeField] private GameObject Boss1HealthBar;

    [SerializeField] private GameObject weaponPrefab; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
           rb.linearVelocity = Vector3.zero;
    }

    void Awake()
    {
        Boss1HealthBar.SetActive(false);
        attackBlocked = false;
        slash.SetActive(false); // Disable the slash object at the start
    }

    void Update()
    {// checking which state it is in currently
        switch (currentMode)
        {
            case MovementState.SideScrollerState:
                HandleSideScrollerMovement();
                SetSpawnersCanSpawn(false); // Disable spawning in side-scroller mode
                break;

            case MovementState.TopDownState:
                HandleTopDownMovement();
                SetSpawnersCanSpawn(true); // Enable spawning in top-down mode
                break;
        }
    }
    void FixedUpdate()
    {
        if (currentMode == MovementState.SideScrollerState)// checking for ground, this is for jumping and shit
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        }
         if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

    }

    private void HandleSideScrollerMovement()
    {// side scroller movement

        weaponPrefab.SetActive(false);
        slash.SetActive(false);
        float moveInput = Input.GetAxis("Horizontal");

        // this is the normal movement
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * movementSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, 0f); // so it doesnt move forward and backwards
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isJumping", false);
        }
        else if (rb.linearVelocity == Vector3.zero)
        {
            animator.SetBool("isMoving", false);
            //animator.SetBool("isJumping", false); 
        }
        else if (Input.GetKeyDown(KeyCode.Space)&&rb.linearVelocity == Vector3.zero )
        {
            //animator.SetBool("isJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
           // animator.SetBool("isJumping", true);
        }
        
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpFloat, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            
        }

        if (!isGrounded && rb.velocity.y > 0f)
        {
            animator.SetBool("isJumping", true);
        }
        

        // this is for doubling dashing
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time - lastTapTimeLeft < doubleTapThreshold && canDash)
            {
                StartCoroutine(Dash(Vector3.left));
            }
            
            lastTapTimeLeft = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time - lastTapTimeRight < doubleTapThreshold && canDash)
            {
                StartCoroutine(Dash(Vector3.right));
            }
            lastTapTimeRight = Time.time;
           
        }

    }
    
    private IEnumerator Dash(Vector3 direction)
    {
        canDash = false;
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f); 
        rb.AddForce(direction * dashImpulse, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f); // so that the player cant abuse the dash mechanic
        canDash = true;
    }

    private void HandleTopDownMovement()
    {
        Boss1HealthBar.SetActive(true);
        weaponPrefab.SetActive(true); 

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        rb.linearVelocity = moveDir * movementSpeed;

        // Handle animation
        animator.SetBool("isMoving", rb.linearVelocity != Vector3.zero);

        // Rotate player toward movement direction
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Handle attack input
        if (Input.GetMouseButtonDown(0))
        {
            if (!attackBlocked)
            {
                animator.SetBool("isAttacking", true);
                Debug.Log(animator.GetBool("isAttacking"));
                Attack();
            }
        }
    }
    

     private void Attack(){
        Debug.Log("triggered");
         slash.SetActive(true);
         attackBlocked = true; // Block attacks during animation
         StartCoroutine(DisableSlashAfterDelay());
    }

     private IEnumerator DisableSlashAfterDelay()
    {
        Debug.Log("Attack animation finished");
        yield return new WaitForSeconds(attackDelay);
        slash.SetActive(false);
        //Debug.Log("Attack animation finished");
        yield return new WaitForSeconds(cooldownTime); // Cooldown after attack animation
        attackBlocked = false;
    }

    public void SetMovementMode(MovementState newMode)// this get called in the trigger to switch the movement
    {
        currentMode = newMode;
        if (newMode == MovementState.TopDownState)// just to make sure theres no added movement from the unused method
        {
            rb.linearVelocity = Vector3.zero;
        }
        else if (newMode == MovementState.SideScrollerState)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // locks the z axis again
        }
    }

    private void SetSpawnersCanSpawn(bool canSpawn)
    {
        // Find all spawners in the scene and set their CanSpawn property
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        if (spawners.Length == 0)
        {
            //1111111111111Debug.LogError("No EnemySpawner objects found in the scene!");
        }
        else
        {
            foreach (EnemySpawner spawner in spawners)
            {
                spawner.SetCanSpawn(canSpawn);
                //Debug.Log($"Spawner {spawner.gameObject.name} CanSpawn set to {canSpawn}");
            }
        }
    }
}
