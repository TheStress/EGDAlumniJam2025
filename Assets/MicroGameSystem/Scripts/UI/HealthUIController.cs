using UnityEngine;

namespace MicroGameSystem {

    public class HealthUIController : MonoBehaviour {
        public void LoseHealth() {
            if (transform.childCount > 0) {
                transform.GetChild(transform.childCount - 1).GetComponent<Animator>().Play("PumpkinLose");
            }
        }
        public void WinMicroGame() {
            Animator[] animators = GetComponentsInChildren<Animator>();
            foreach (Animator animator in animators) {
                animator.Play("PumpkinWin");
            }
        }
    }

}