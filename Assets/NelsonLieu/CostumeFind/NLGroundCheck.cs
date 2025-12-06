using UnityEngine;

public class NLGroundCheck : MonoBehaviour {
    public LayerMask groundMask;
    public float height;
    public bool Check() {
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.01f, Vector3.down, out hit, height, groundMask);
    }
}
