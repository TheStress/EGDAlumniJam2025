using UnityEngine;

public class KP_Player : MonoBehaviour
{
    public GameObject objectToSpawnPrefab;
    public Transform spawnPoint;

    public float moveSpeed = 5f; // Adjust speed in the Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D keys or Left/Right arrow keys
        float verticalInput = Input.GetAxis("Vertical");   // W/S keys or Up/Down arrow keys

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Apply movement to the object's position
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        
        //Debug.Log(verticalInput);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(objectToSpawnPrefab, spawnPoint.position, Quaternion.identity);
            FindFirstObjectByType<KP_GhostGM>().win = true;
        }
        }
   
}
