using System.Data;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    [SerializeField] float shakeMag = 1;
    float currentMag = 0;
    Vector2 initalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initalPosition + Random.insideUnitCircle * currentMag;
        currentMag = Mathf.Lerp(currentMag, 0, 0.2f);
    }
    public void StartShake()
    {
        currentMag = shakeMag;
    }
}
