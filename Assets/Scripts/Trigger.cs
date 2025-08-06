using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform tpPoint;
    private CamSwitch camSwitch;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        camSwitch = FindObjectOfType<CamSwitch>();
    }

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Its popping off");
            other.transform.position = tpPoint.position;
            camSwitch.switchCam(camSwitch.cam2);
            MainMovementScript PlayerMovement = other.gameObject.GetComponent<MainMovementScript>();
            if (PlayerMovement != null)
            {
                PlayerMovement.SetMovementMode(MainMovementScript.MovementState.TopDownState);
            }
        }
       // OnTriggerEnter(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Its popping off");
            other.transform.position = tpPoint.position;
             camSwitch.switchCam(camSwitch.cam2);
             MainMovementScript PlayerMovement = other.gameObject.GetComponent<MainMovementScript>();
             if (PlayerMovement != null)
             {
                 PlayerMovement.SetMovementMode(MainMovementScript.MovementState.TopDownState);
             }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
           
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
