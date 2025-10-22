using UnityEngine;
namespace Nelson
{

    public class ClickOnCandy : MonoBehaviour
    {
        [SerializeField] Vector2 healthRange = new Vector2(0, 0);
        float currentHealth = 0;
        
        private void Start()
        {
            currentHealth = Random.Range(healthRange.x, healthRange.y);
        }
        private void OnMouseDown()
        {
            currentHealth--;
            if(currentHealth <= 0)
            {

            }
        }

    }
}