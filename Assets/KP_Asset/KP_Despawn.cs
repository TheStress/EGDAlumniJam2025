using UnityEngine;
using System.Collections; // Required for Coroutines

public class KP_Despawn : MonoBehaviour
{
    public float despawnTime = 5f; // Time in seconds before despawning

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject); // Destroy the GameObject
    }
}