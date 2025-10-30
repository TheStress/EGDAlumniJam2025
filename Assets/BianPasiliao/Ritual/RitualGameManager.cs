using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace Bian {
    public enum RitualItemType {
        None,
        BatWing,
        Eye,
        Hair,
        Mushroom,
        RatTail
    }

    public class RitualGameManager : MicroGameManager {
        public const int itemCount = 5;

        //public Color[] itemColors = new Color[itemCount];
        public List<Sprite> itemSprites = new List<Sprite>();
        public List<Sprite> itemIconSprites = new List<Sprite>();
        public List<Sprite> spotSprites = new List<Sprite>();

		public List<RitualItem> items = new List<RitualItem>();
        public List<RitualSpot> spots = new List<RitualSpot>();
        public List<RitualSpot> spotsCopy = new List<RitualSpot>();
        public List<SpriteRenderer> icons = new List<SpriteRenderer>();

        private RitualItem currentHeldItem;


        public void CheckWin() {
            bool tempWin = true;
            foreach (RitualItem item in items) {
                if (!item.CheckIfCorrect()) {
					tempWin = false;
                    break;
                }
            }

            win = tempWin;
            Debug.Log("win");
        }

        private void Start() {
            List<RitualItem> shuffledItems = new List<RitualItem>();
            for (int i = 0; i < itemCount; i++) {
                int randomIndex = Random.Range(0, items.Count - 1);
                RitualItem randomItem = items[randomIndex];
                randomItem.SetItemType(i);

				shuffledItems.Add(randomItem);
                items.RemoveAt(randomIndex);
            }
            items = shuffledItems;

            spotsCopy = new List<RitualSpot>(spots);
			List<RitualSpot> shuffledSpots = new List<RitualSpot>();
			for (int i = 0; i < itemCount; i++) {
				int randomIndex = Random.Range(0, spots.Count - 1);
				RitualSpot randomSpot = spots[randomIndex];
				randomSpot.SetItemType(i);

				shuffledSpots.Add(randomSpot);
				spots.RemoveAt(randomIndex);
			}
			spots = shuffledSpots;

            for (int i = 0; i < itemCount; i++) {
                RitualItemType spotItemType = spotsCopy[i].GetItemType();
                icons[i].sprite = itemIconSprites[(int)spotItemType - 1];
            }

		}

	    public override void OnStartMicroGame() {

        }

        public override void OnEndMicroGame() {

        }

        public RitualItem GetHeldItem() {
            return currentHeldItem;
        }

        public RitualItemType GetHeldItemType() {
            if (currentHeldItem != null) {
                return currentHeldItem.GetItemType();
            }

            return RitualItemType.None;
        }

        public void UpdateHeldItem(RitualItem item) {
            currentHeldItem = item;
        }

        
    }
}
