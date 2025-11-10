using UnityEngine;

public class MASwapSprite : MonoBehaviour
{
    public ClickDrag left_arm;
    public ClickDrag right_arm;
    public ClickDrag left_leg;
    public ClickDrag right_leg;

    public Sprite smile;
    public SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SwapToSmile();
    }

    void SwapToSmile()
    {
        if (left_arm.inPlace && right_arm.inPlace && left_leg.inPlace && right_leg.inPlace)
        {
            sr.sprite = smile;
        }
    }
}
