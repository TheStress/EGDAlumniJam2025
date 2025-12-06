using UnityEngine;

public class NLPlayerMovement : MonoBehaviour {
    NLGroundCheck groundCheck;
    Rigidbody rb;

    public float accel = 7;
    public float maxSpeed = 7;
    public float groundDrag = 10;
    public float airDrag = 3;

    Vector3 inputDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<NLGroundCheck>();
    }

    // Update is called once per frame
    void Update() {
        // Adding horizontal movement
        inputDir = Input.GetAxisRaw("Horizontal") * Camera.main.transform.right + Input.GetAxisRaw("Vertical") * Camera.main.transform.forward;
        inputDir.y = 0;
        inputDir.Normalize();
        if (inputDir.magnitude > 0.01f) {
            AddSpeed(inputDir * accel * Time.deltaTime);
        }


        // Drag
        if (groundCheck.Check()) {
            rb.linearDamping = groundDrag;
        }
        else {
            rb.angularDamping = airDrag;
        }
    }

    public void AddSpeed(Vector3 velocity) {
        Vector3 newVel = rb.linearVelocity + velocity;
        if (newVel.magnitude > maxSpeed) {
            newVel = newVel.normalized * maxSpeed;
        }
        rb.linearVelocity = newVel;
    }
}
