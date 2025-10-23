using UnityEngine;
using System.Collections.Generic;
namespace Nelson
{

    public class ClickOnCandy : MonoBehaviour
    {
        [SerializeField] List<Sprite> candyStages = new List<Sprite>();
        [SerializeField] Vector2 healthRange = new Vector2(0, 0);
        [SerializeField] GameObject bladePrefab;

        int currentHealth = 0;
        ObjectShake objectShake;
        SpriteRenderer spriteRenderer;
        bool hasRazor = false;

        private void Start()
        {
            objectShake = GetComponent<ObjectShake>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            currentHealth = Random.Range((int)healthRange.x, (int)healthRange.y);
            spriteRenderer.sprite = candyStages[currentHealth-1];
        }

        private void OnMouseDown()
        {
            currentHealth--;
            objectShake.StartShake();
            if (currentHealth <= 0)
            {
                if(hasRazor)
                {
                    FindFirstObjectByType<RazorBladeGameManager>().win = true;
                    Instantiate(bladePrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            else
            {
                spriteRenderer.sprite = candyStages[currentHealth - 1];
            }
        }

        public void HasRazor()
        {
            hasRazor = true;
        }
    }
}