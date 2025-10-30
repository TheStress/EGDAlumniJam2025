using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace Bian {
    public enum RitualItemType {
        None,
        Type1,
        Type2,
        Type3,
        Type4,
        Type5
    }

    public class RitualGameManager : MicroGameManager {
        public const int itemCount = 5;

        public Color[] itemColors = new Color[itemCount];

        public List<RitualItem> items = new List<RitualItem>();
        public List<RitualSpot> spots = new List<RitualSpot>();

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
        }

        private void Start() {
            List<RitualItem> shuffledItems = new List<RitualItem>();
            for (int i = 0; i < itemCount; i++) {
                Debug.Log(items.Count);
                int randomIndex = Random.Range(0, items.Count - 1);
                RitualItem randomItem = items[randomIndex];
                randomItem.SetItemType((RitualItemType)(i + 1), itemColors[i]);

				shuffledItems.Add(randomItem);
                items.RemoveAt(randomIndex);
            }
            items = shuffledItems;

		    List<RitualSpot> shuffledSpots = new List<RitualSpot>();
			for (int i = 0; i < itemCount; i++) {
				int randomIndex = Random.Range(0, items.Count - 1);
				RitualSpot randomSpot = spots[randomIndex];
				randomSpot.SetItemType((RitualItemType)(i + 1), itemColors[i]);

				shuffledSpots.Add(randomSpot);
				spots.RemoveAt(randomIndex);
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
