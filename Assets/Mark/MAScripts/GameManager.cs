using UnityEngine;

public class GameManager : MicroGameManager
{
    public ClickDrag left_arm;
    public ClickDrag right_arm;
    public ClickDrag left_leg;
    public ClickDrag right_leg;

    
    public override void OnEndMicroGame()
    {
        
    }

    public override void OnStartMicroGame()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (left_arm.inPlace &&  right_arm.inPlace && left_leg.inPlace && right_leg.inPlace) 
        {
            Debug.Log("you win");
        }
    }
}
