using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

namespace MicroGameSystem {

    public class MicroGameSequencer : MonoBehaviour {
        public List<string> microGameSeneNames = new List<string>();
        string currentlyLoadedScene = "";
        public UnityEvent OnCompleteSceneLoad = new UnityEvent();

        public IEnumerator SpawnNextMicroGame() {
            if (currentlyLoadedScene != "") {
                yield return SceneManager.UnloadSceneAsync(currentlyLoadedScene);
            }
            currentlyLoadedScene = GetRandomSceneName();
            yield return SceneManager.LoadSceneAsync(currentlyLoadedScene, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentlyLoadedScene));
            OnCompleteSceneLoad.Invoke();
        }

        public string GetRandomSceneName() {
            int randomIndex = Random.Range(0, microGameSeneNames.Count);
            // MAKE SURE THEY ARE UNIQUE GAMES FOR A SEQUENCE

            return microGameSeneNames[randomIndex];
        }
    }

}