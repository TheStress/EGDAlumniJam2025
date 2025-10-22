using UnityEngine;

public class TestMicroGameManager : MicroGameManager
{
    public bool setWin = false;
    public override void OnEndMicroGame() {
    }
    public override void OnStartMicroGame() {
        win = setWin;
    }
}
