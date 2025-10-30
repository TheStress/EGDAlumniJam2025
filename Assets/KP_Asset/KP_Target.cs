using UnityEngine;

public class KP_Target : MonoBehaviour
{
    public float initialForceMagnitude = 5f;
    private Rigidbody2D rb;

    [System.Obsolete]
    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Give the object an initial velocity to start moving
        // We use a random direction to make it less predictable
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomDirection * initialForceMagnitude, ForceMode2D.Impulse);
    }
}