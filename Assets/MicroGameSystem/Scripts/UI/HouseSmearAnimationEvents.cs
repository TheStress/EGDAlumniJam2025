using UnityEngine;

namespace MicroGameSystem {

    public class HouseSmearAnimationEvents : MonoBehaviour {
        [SerializeField] MacroGameManager gameManager;
        [SerializeField] PickRandomSprite candySprite;
        public void OnEndCloseZoom() {
            gameManager.OnEndCloseZoom();
        }
        public void OnEndOpenZoom() {
            gameManager.OnEndOpenZoom();
        }
        public void OnSpawnCandy() {
            candySprite.SetRandomSprites();
        }

        public void OnEndGameResultAnimation() {
            gameManager.StartNextMicroGame();
        }
    }

}