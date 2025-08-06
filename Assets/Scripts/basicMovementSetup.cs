using UnityEngine;

public class basicMovementSetup : MonoBehaviour
{
     public float moveSpeed = 5f;
       public float jumpForce = 8f;
   
       private Rigidbody rb;
       private bool isGrounded;
   
       public Transform groundCheck;
       public float groundCheckRadius = 0.2f;
       public LayerMask groundLayer;
   
       void Start()
       {
           rb = GetComponent<Rigidbody>();
       }
   
       void Update()
       {
            //Move left/right
           float moveInput = Input.GetAxis("Horizontal");
           Vector3 velocity = rb.linearVelocity;
           velocity.x = moveInput * moveSpeed;
           rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, 0); // lock Z to 0*/
   
           // Jump
           if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
           {
               Debug.Log("jump should work");
               rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           }
   
           // Keep player aligned to 2D plane
       
       }
   
       void FixedUpdate()
       {
           // Check if grounded using an overlap circle
           isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
       }
}
