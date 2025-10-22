using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MicroGameSystem {
    public class EndMenu : MonoBehaviour {

        [SerializeField] TMP_Text stats;
        public void ReloadGameLoop() {
            SceneManager.LoadScene("GameLoopScene");
        }
        public void UpdateStats(MacroGameManager macroGameManager) {
            stats.text = "Games Completed: " + macroGameManager.numOfGamesWon.ToString() + "\nSpeed Level: " + macroGameManager.GetPercentIncrease()*100f+"%";
        }
    }

}