using UnityEngine;

namespace Bian
{

    public class RitualItem : MonoBehaviour
    {
        private RitualGameManager gameManager;
        [SerializeField] private SpriteRenderer sprite;

        [SerializeField] private RitualItemType itemType;


        private void Start()
        {
            gameManager = FindAnyObjectByType<RitualGameManager>().GetComponent<RitualGameManager>();
            sprite.color = gameManager.itemColors[(int)itemType - 1];    // -1 to skip None
        }

        private void Update()
        {
            //Vector3 mousePosition = Input.mousePosition;
            //mousePosition.z = 1;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Debug.Log(mousePosition);
            //mousePosition = new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane);
            //Debug.Log(mousePosition);
        }

        private void OnMouseDrag() // cause 3d
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            gameManager.UpdateHeldItem(this);
        }

        private void OnMouseUp() {
            gameManager.UpdateHeldItem(null);
        }

        public RitualItemType GetItemType()
        {
            return itemType;
        }
    }
}

