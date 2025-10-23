using UnityEngine;
using UnityEngine.UI;

namespace Benicio
{
    public class HeartbeatManager : MicroGameManager
    {
        public float heartDeplete;
        public float heartAdd;
        float heartMeter = 0;
        public float winValue;
        public Image debugMeter;
        public Image debugWinVal;
        bool finished = false;
        public GameObject heart;
        public float finishTimer;
        public override void OnEndMicroGame()
        {
        }

        public override void OnStartMicroGame()
        {

        }

        private void Start()
        {
            debugWinVal.fillAmount = winValue;
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
            
            debugMeter.fillAmount = heartMeter;
            if (finished) return;
            finishTimer += Time.deltaTime;
            if(finishTimer > 9f && !finished)
            {
                finished = true;
                if(heartMeter > winValue)
                {
                    win = true;
                    debugMeter.color = Color.blue;
                }
            }

            if(heartMeter > 0)
            {
                heartMeter -= heartDeplete * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                heartMeter += heartAdd;
            }

            if( heartMeter > 1)
            {
                win = false;
                finished = true;

                debugMeter.color = Color.red;
            }
        }
    }
}
