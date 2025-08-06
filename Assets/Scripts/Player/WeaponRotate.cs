using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 mousePos = ray.GetPoint(distance);
            Vector3 direction = mousePos - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
