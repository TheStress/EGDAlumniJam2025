using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace Bian {

    public class RitualItem : MonoBehaviour {
        private RitualGameManager gameManager;
        [SerializeField] private SpriteRenderer sprite;

        private RitualItemType itemType;

        private RitualSpot placedSpot = null;


		public void SetItemType(RitualItemType type, Color color) {
			itemType = type;
			sprite.color = color;
		}

		public RitualItemType GetItemType() {
            return itemType;
        }

        public void PlaceOnSpot(RitualSpot spot) {
			Debug.Log("item placed");
            placedSpot = spot;
			transform.position = spot.transform.position;
			gameManager.CheckWin();
		}

		public void RemoveFromSpot() {
			Debug.Log("item removed");
			placedSpot = null;
		}

		public bool CheckIfCorrect() {
			return itemType == placedSpot.GetItemType();
		}


		private void Start() {
			gameManager = FindAnyObjectByType<RitualGameManager>().GetComponent<RitualGameManager>();
		}

		private void Update() {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits) {
				if (hit.collider.gameObject == this.gameObject) {

					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("mouse down on item");
						gameManager.UpdateHeldItem(this);
						RemoveFromSpot();
					}
				}
			}

			if (Input.GetMouseButton(0)) {
				if (gameManager.GetHeldItem() == this && placedSpot == null) {
					Move();
				}
			}

			if (Input.GetMouseButtonUp(0)) {
				gameManager.UpdateHeldItem(null);
			}
		}

		private void Move() {
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 10;       // distance of camera
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
		}

		
	}
}

