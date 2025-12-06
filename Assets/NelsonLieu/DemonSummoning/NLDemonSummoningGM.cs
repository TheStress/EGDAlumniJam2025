using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nelson {
    public enum ArrowInput { 
        LEFT,
        RIGHT,
        UP,
        DOWN,
        NONE
    }

    public class NLDemonSummoningGM : MicroGameManager {
        public List<ArrowInput> inputsRequired = new List<ArrowInput>();
        int maxArrows = 5;
        bool canInput = false;

        public override void OnEndMicroGame() {

        }
        public override void OnStartMicroGame() {
            AddArrows();
        }

        IEnumerator AddArrows() {
            inputsRequired.Add((ArrowInput)Random.Range(0,3));

            yield return new WaitForSecondsRealtime(0.2f);
            if(inputsRequired.Count < maxArrows) {
                StartCoroutine(AddArrows());
            }
            else {
                canInput = true;
            }
        }

        void Update() {
            base.Update();

            ArrowInput playerInput = ArrowInput.NONE;
            if(canInput) {
                if (Input.GetKeyDown(KeyCode.RightArrow)) { playerInput = ArrowInput.RIGHT; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { playerInput = ArrowInput.LEFT; }
                if (Input.GetKeyDown(KeyCode.UpArrow)) { playerInput = ArrowInput.UP; }
                if (Input.GetKeyDown(KeyCode.DownArrow)) { playerInput = ArrowInput.DOWN; }
                if (inputsRequired[inputsRequired.Count-1] == playerInput) {
                    inputsRequired.RemoveAt(inputsRequired.Count - 1);
                }
            }
            
        }

    }


}


