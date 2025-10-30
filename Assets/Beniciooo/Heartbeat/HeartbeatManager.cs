using UnityEngine;
using UnityEngine.UI;

namespace Benicio
{
    public class HeartbeatManager : MicroGameManager
    {
        public float heartDeplete;
        public float heartAdd;
        float heartMeter;
        public float winValue;
        public Image debugMeter;
        public Image debugWinVal;
        bool finished = false;
        public GameObject heart;
        public SpriteRenderer heartSprite;
        Animator animator;
        public float popValue;
        public override void OnEndMicroGame()
        {

        }

        public override void OnStartMicroGame()
        {
            animator.Play("intro");
        }

        private void Start()
        {
            heartMeter = winValue;
            debugWinVal.fillAmount = winValue;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            if (IsGameActive())
            {
                heart.transform.localScale = Vector3.one * (1 + heartMeter);
                animator.SetFloat("shakeVal", heartMeter);
                debugMeter.fillAmount = heartMeter;
                if (finished) return;
                if (GetCurrentTime() < GetMaxTime() * 0.1f && !finished)
                {
                    finished = true;
                    animator.Play("outro");
                    if (heartMeter > winValue)
                    {
                        animator.Play("livingLoop");
                        win = true;
                        debugMeter.color = Color.blue;
                    }

                }

                if (heartMeter > winValue)
                {
                    heartSprite.color = Color.Lerp(Color.white, Color.red, heartMeter - winValue);
                }
                else
                {
                    heartSprite.color = Color.white;
                }

                if (heartMeter > 0)
                {
                    heartMeter -= heartDeplete * Time.deltaTime;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    heartMeter += heartAdd;
                    animator.Play("heartbeatAnim", 0, 0);
                }

                if (heartMeter > popValue)
                {
                    win = false;
                    finished = true;
                    animator.Play("heartPop");
                    debugMeter.color = Color.red;
                }
            }
           
        }
    }
}
