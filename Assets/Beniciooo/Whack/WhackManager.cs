using UnityEngine;


namespace Benicio
{

    public class WhackManager : MicroGameManager
    {
        public GameObject shovel;
        Animator animator;
        public float zombieClimbRate;
        public float skeletonClimbRate;
        bool[] graveActive = new bool[7];
        bool[] isSkeleton = new bool[7];
        float[] climbs = new float[7];
        public float loseCondition;
        public GameObject[] hands = new GameObject[7];
        float timer;
        public Sprite zombieHand;
        public Sprite skeletonHand;
        public GameObject loseDebug;
        public float whackValue;
        public float spawnTime;
        bool climbing;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            climbing = true;
            animator = GetComponent<Animator>();
            foreach(GameObject hand in hands)
            {
                hand.transform.localPosition = Vector3.zero;
            }
            win = true;
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            shovel.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;

            timer += Time.deltaTime;

            if(timer >= spawnTime)
            {
                int random = Random.Range(0, 7);
                bool skeleton = (Random.Range(0, 2) > 0.5f);
                if (!graveActive[random]) 
                {
                    if (skeleton)
                    {
                        hands[random].GetComponent<SpriteRenderer>().sprite = skeletonHand;
                        isSkeleton[random] = true;
                    }
                    else
                    {
                        hands[random].GetComponent<SpriteRenderer>().sprite = zombieHand;
                        isSkeleton[random] = false;
                    }
                        graveActive[random] = true;
                }
                timer = 0;
            }


            for(int i = 0; i < hands.Length; i++)
            {
                if (graveActive[i])
                {
                    if (isSkeleton[i])
                    {
                        climbs[i] += Time.deltaTime * skeletonClimbRate;
                    }
                    else
                    {
                        climbs[i] += Time.deltaTime * zombieClimbRate;
                    }
                }

                if (climbing)
                {
                    hands[i].transform.localPosition = Vector3.up * (climbs[i] / loseCondition) * 2.62f;
                }

                if (climbs[i] > loseCondition)
                {
                    climbing = false;
                    loseDebug.SetActive(true);
                }
            }


            if(Input.GetMouseButtonDown(0))
            {
                animator.Play("shovelSwing");
                Collider2D overlap = Physics2D.OverlapCircle((Vector2)shovel.transform.position, 1f);
                for(int i = 0;i < hands.Length;i++)
                {
                    if(overlap.gameObject == hands[i])
                    {
                        climbs[i] -= whackValue;
                    }
                }
            }

        }

        public override void OnStartMicroGame()
        {

        }

        public override void OnEndMicroGame()
        {
            if (climbing) win = true;
        }

        
    }
}
