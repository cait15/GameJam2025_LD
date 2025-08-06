using UnityEngine;

public class FollowScript : MonoBehaviour
{

   public Transform targetObj; 

   private void Awake(){
    targetObj = GameObject.FindGameObjectWithTag("Player").transform;
   }
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
    }
}
