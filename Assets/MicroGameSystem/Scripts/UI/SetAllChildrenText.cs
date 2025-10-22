using UnityEngine;
using TMPro;

namespace MicroGameSystem {

    public class SetAllChildrenText : MonoBehaviour {
        [SerializeField] GameObject selectedObject;
        public void SetText(string text) {
            TMP_Text[] texts = selectedObject.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text textFound in texts) {
                textFound.text = text;
            }
        }
    }

}