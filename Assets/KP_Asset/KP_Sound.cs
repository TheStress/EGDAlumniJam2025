using UnityEngine;

public class KP_Sound : MonoBehaviour
{
    public AudioSource spawnSoundSource; // Assign this in the Inspector

    void Start()
    {
        if (spawnSoundSource != null)
        {
            spawnSoundSource.Play();
        }
    }
}

