using UnityEngine;

public class KP_Interact : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("InteractableObject"))
        {
            if (collision.contacts[0].normal.y == 1)
            {
                if (Input.GetKeyDown(KeyCode.E)) // Check for 'E' key press
                {
                    Debug.Log("Player is on top of InteractableObject and pressed E!");
                    // Trigger interaction logic here
                }
            }
        }
    }
}
