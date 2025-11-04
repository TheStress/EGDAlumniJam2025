using UnityEngine;


namespace Benicio
{

    public class WhackManager : MicroGameManager
    {
        public GameObject shovel;
        Animator animator;
        public float zombieClimbRate;
        public float skeletonClimbRate;
        bool[] graves = new bool[7];
        float[] climbs = new float[7];
        public float loseCondition;
        public GameObject[] hands = new GameObject[7];
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            animator = GetComponent<Animator>();
            foreach(GameObject hand in hands)
            {
                hand.transform.localPosition = Vector3.zero;
            }
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            shovel.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            




            if(Input.GetMouseButtonDown(0))
            {
                animator.Play("shovelSwing");
            }

        }

        public override void OnStartMicroGame()
        {

        }

        public override void OnEndMicroGame()
        {

        }
    }
}
