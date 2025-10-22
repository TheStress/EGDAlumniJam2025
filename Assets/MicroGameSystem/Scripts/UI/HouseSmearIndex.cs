using JetBrains.Annotations;
using UnityEngine;

namespace MicroGameSystem {

    public class HouseSmearIndex : MonoBehaviour {
        [SerializeField] public float houseIndex = 0;
        RectTransform rectTransform;
        [SerializeField] float zeroIndexX = 4331;
        [SerializeField] float houseWidth = 409.6f;
        [SerializeField] float houseCount = 5.5f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            rectTransform = GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void Update() {
            houseIndex = houseIndex % (houseCount-1);

            if (houseIndex < 0) {
                houseIndex = 5;
            }
            float newX = zeroIndexX - houseIndex * houseWidth * rectTransform.localScale.x;
            rectTransform.anchoredPosition = new Vector3(newX, 0, 0);
        }
    }

}