using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace MicroGameSystem {

    public class PickRandomSprite : MonoBehaviour {
        [SerializeField] List<Sprite> sprites;

        public void SetRandomSprites() {
            Image[] images = GetComponentsInChildren<Image>();
            foreach (Image image in images) {
                image.sprite = sprites[Random.Range(0, sprites.Count)];
            }
        }

        public void SetRandomSingleSprite() {
            GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }

}