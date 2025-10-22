using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MicroGameSystem {

    public class MicroGameTimerUI : MonoBehaviour {
        MicroGameManager owner;
        float value = 1;
        [SerializeField] GameObject candySlider;

        public void SetOwner(MicroGameManager manager) {
            owner = manager;
        }

        // Update is called once per frame
        void Update() {
            if (owner != null) {
                value = owner.GetCurrentTime() / owner.GetMaxTime();

                int childIndex = Mathf.Clamp(Mathf.FloorToInt(candySlider.transform.childCount*value), 0, candySlider.transform.childCount-1);
                Transform candyChild = candySlider.transform.GetChild(childIndex);
                if (candyChild.localScale.x == 1) {
                    candyChild.GetComponent<ScaleShrinkJuice>().Activate();
                }
            }
        }

        public void ResetSlider() {
            PickRandomSprite[] candyChildren = candySlider.GetComponentsInChildren<PickRandomSprite>();
            foreach(PickRandomSprite setSprite in candyChildren) {
                setSprite.SetRandomSingleSprite();
                setSprite.transform.localScale = Vector3.one;
            }
        }
    }

}