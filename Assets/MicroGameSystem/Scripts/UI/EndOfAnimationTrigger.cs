using UnityEngine;
using UnityEngine.Events;

namespace MicroGameSystem {

    public class EndOfAnimationTrigger : MonoBehaviour {
        public UnityEvent onEndAnimation = new UnityEvent();
        public void EndOfAnimation() {
            onEndAnimation.Invoke();
        }
    }

}