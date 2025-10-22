using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MicroGameSystem {

    public class MacroGameManager : MonoBehaviour {
        [SerializeField] int maxLives = 4;
        int currentLives = 0;
        public int numOfGamesWon = 0;

        // Speedup
        [SerializeField] int increaseSpeedThreshold = 5;
        [SerializeField] int numOfSuccesses = 0;
        [SerializeField] float microGameTimerBase = 5f;
        [SerializeField] float timerFactor = 1;
        [SerializeField] float speedUpAmount = 0.1f;
        [SerializeField] float timeMinimum = 0.5f;


        // Micro game managers
        MicroGameSequencer microGameSequencer;
        MicroGameManager currentMicroGameManager = null;

        // Animation Variables
        [SerializeField] GameObject cameraObject;
        [SerializeField] Animator housesAnimmator;
        [SerializeField] Animator textAnimator;
        HealthUIController healthUIController;
        HouseSmearJuice houseSmearJuice;

        //UI
        [SerializeField] GameObject endScreen;

        public float GetPercentIncrease() {
            return 1f-timerFactor;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            healthUIController = FindFirstObjectByType<HealthUIController>();
            houseSmearJuice = FindFirstObjectByType<HouseSmearJuice>();
            microGameSequencer = GetComponent<MicroGameSequencer>();
            houseSmearJuice.OnCompleteEffect.AddListener(OnCompleteHouseTransition);
            microGameSequencer.OnCompleteSceneLoad.AddListener(StartMicroGame);
            currentLives = maxLives;
        }

        public void StartNextMicroGame() {
            if (currentLives > 0) {
                houseSmearJuice.Activate();
            }
            else {
                GameOver();
            }
        }

        public void OnCompleteHouseTransition() {
            StartCoroutine(microGameSequencer.SpawnNextMicroGame());
        }

        public void StartMicroGame() {
            FindFirstObjectByType<MicroGameTimerUI>().ResetSlider();
            cameraObject.SetActive(false); // Disable the game loop camera
            housesAnimmator.SetTrigger("CloseZoom");
        }

        public void OnEndOpenZoom() {
            currentMicroGameManager = FindFirstObjectByType<MicroGameManager>();
            currentMicroGameManager.InitalizeGameManagerData(microGameTimerBase * timerFactor);
            currentMicroGameManager.OnEndMicroGameEvent.AddListener(OnCompleteMicroGame);
            FindFirstObjectByType<MicroGameTimerUI>().SetOwner(currentMicroGameManager);
            textAnimator.GetComponent<SetAllChildrenText>().SetText(currentMicroGameManager.GetStartingText());
            textAnimator.Play("InfoTextIn");
            currentMicroGameManager.OnStartMicroGame();
        }

        public void OnCompleteMicroGame() {
            housesAnimmator.SetTrigger("OpenZoom");
        }

        public void OnEndCloseZoom() {
            cameraObject.SetActive(true); // Enable the game loop camera
            UpdateHealth();
            if (currentMicroGameManager.win) {
                housesAnimmator.SetTrigger("WinGame");
                WonGame();
            }
            else {
                housesAnimmator.SetTrigger("LoseGame");
                LostGame();
            }
        }

        public void UpdateHealth() {
            if (currentMicroGameManager.win) {
                healthUIController.WinMicroGame();
            }
            else {
                healthUIController.LoseHealth();
            }
        }


        private void WonGame() {
            numOfGamesWon++;
            numOfSuccesses++;
            if (numOfSuccesses >= increaseSpeedThreshold) {
                textAnimator.Play("SpeedUp");
                numOfSuccesses = 0;
                timerFactor = Mathf.Max(timeMinimum, timerFactor - speedUpAmount);
                housesAnimmator.speed = 1 + (1 - timerFactor);
                textAnimator.speed = 1 + (1 - timerFactor);
            }
        }
        private void LostGame() {
            currentLives -= 1;
        }

        public void GameOver() {
            endScreen.SetActive(true);
            endScreen.GetComponent<EndMenu>().UpdateStats(this);
        }
    }

}