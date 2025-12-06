using Nelson;
using UnityEngine;

public class NLArrowUI : MonoBehaviour
{
    [SerializeField] NLDemonSummoningGM owner;
    int previousCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ownerArrowCount = owner.inputsRequired.Count;
        if (ownerArrowCount != previousCount) {

        }
    }
}
