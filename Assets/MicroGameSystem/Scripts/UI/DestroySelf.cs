using UnityEngine;

namespace MicroGameSystem {

    public class DestroySelf : MonoBehaviour {
        public void OnEndAnimation() {
            Destroy(gameObject);
        }
    }

}