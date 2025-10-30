using UnityEngine;
using System.Collections;

namespace Bian {

    public class RitualSpot : MonoBehaviour {
        private RitualGameManager gameManager;
        [SerializeField] private SpriteRenderer sprite;

        private RitualItemType itemType;

		private RitualItem placedItem = null;

		private bool isHovering;

		public void SetItemType(RitualItemType type, Color color) {
			itemType = type;

			color = new Color(color.r, color.g, color.b, 0.3f);
			sprite.color = color;
		}

		public RitualItemType GetItemType() {
			return itemType;
		}

		private void Start() {
            gameManager = FindAnyObjectByType<RitualGameManager>().GetComponent<RitualGameManager>();
        }

		private void Update() {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);

			bool isHit = false;
			foreach (RaycastHit hit in hits) {
				if (hit.collider.gameObject == this.gameObject) {
					isHit = true;
				}
			}

			if (!isHovering && isHit) {
				isHovering = true;

				Debug.Log("mouse entered spot");
				RitualItem heldItem = gameManager.GetHeldItem();
				if (heldItem != null && placedItem == null) {
					heldItem.PlaceOnSpot(this);
					placedItem = heldItem;
				}

			} else if (isHovering && !isHit) {
				isHovering = false;

				RitualItem heldItem = gameManager.GetHeldItem();
				if (heldItem != null) {
					heldItem.RemoveFromSpot();
					placedItem = null;
				}
			}
		}

	}
}

