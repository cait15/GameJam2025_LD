using UnityEngine;

public class PaulPickup : MonoBehaviour
{

    public GameObject UpgradeScreen;

    public void Start()
    {
        UpgradeScreen.SetActive(false); // Ensure the UpgradeScreen is inactive at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("Player has picked up Paul!");
            UpgradeScreen.SetActive(true); // Show the upgrade screen when the player picks up Paul
        }
    }

}
