using UnityEngine;

namespace MicroGameSystem {

    public class MainMenu : MonoBehaviour {
        [SerializeField] MacroGameManager gameManager;

        public void StartGame() {
            Destroy(gameObject);
            gameManager.StartNextMicroGame();
        }
    }

}