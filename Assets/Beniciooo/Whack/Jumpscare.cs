using UnityEngine;


namespace Benicio
{
    public class Jumpscare : MonoBehaviour
    {
        float lerpVal;
        public float lerpRate;
        public Transform jumpTo;
        Animator animator;
        bool played = false;
        Vector3 startPos;
        Vector3 startScale;
        AudioSource audioSource;
        public AudioClip scareSound;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            lerpVal = 0;
            startPos = transform.position;
            startScale = transform.localScale;
            jumpTo = GameObject.Find("jumpToPos").transform;
        }

        // Update is called once per frame
        void Update()
        {
            if(lerpVal < 1)
            {
                lerpVal += Time.deltaTime * lerpRate;
            }

            if (lerpVal >= 1 && !played)
            {
                animator.Play("jumpscareShake");
                audioSource.PlayOneShot(scareSound);
                played = true;
            }
            

                transform.position = Vector3.Lerp(startPos, jumpTo.position, lerpVal);
            transform.localScale = Vector3.Lerp(startScale, jumpTo.localScale, lerpVal);
        }
    }
}
