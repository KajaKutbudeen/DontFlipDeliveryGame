using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public MenuManager _MenuManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {          
            Destroy(collision.gameObject);           
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Cursor.lockState = CursorLockMode.None;
            _MenuManager.GameFailed();
        }
    }
}
