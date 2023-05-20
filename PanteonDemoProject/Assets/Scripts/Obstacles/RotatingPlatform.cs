using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2;
    [SerializeField] private bool isPlatformRotatingRight;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var adjustSpeed = rotationSpeed * Time.deltaTime;
            
            other.transform.position += (isPlatformRotatingRight ?Vector3.right : Vector3.left) * adjustSpeed;
            
            Debug.Log("RotatingPlatform");
        }
        
    }
}
