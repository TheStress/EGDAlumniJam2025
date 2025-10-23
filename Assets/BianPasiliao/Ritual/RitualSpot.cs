using UnityEngine;

namespace Bian
{

    public class RitualSpot : MonoBehaviour
    {
        private RitualGameManager gameManager;
        [SerializeField] private SpriteRenderer sprite;

        [SerializeField] private RitualItemType itemType;

        private bool hasCorrectItem = false;

        private void Start()
        {
            gameManager = FindAnyObjectByType<RitualGameManager>().GetComponent<RitualGameManager>();
            Color itemColor = gameManager.itemColors[(int)itemType - 1];    // -1 to skip None
            itemColor = new Color(itemColor.r, itemColor.g, itemColor.b, 0.3f);
            sprite.color = itemColor;
        }

        private void OnMouseEnter()
        {
            RitualItem heldItem = gameManager.GetHeldItem();
            if (heldItem != null)
            {
                heldItem.transform.position = transform.position;
            }

            hasCorrectItem = gameManager.GetHeldItemType() == itemType;
        }
    }
}

