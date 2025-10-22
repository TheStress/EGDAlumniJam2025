using UnityEngine;
using UnityEngine.Events;
public abstract class MicroGameManager : MonoBehaviour {
    /// <summary>
    /// - You need to inherit this class in order for the MacroGameManager to begin the game properly
    /// - If you want to override the Update() function of this class make sure you still run it with base.Update()
    /// - Additionally this system uses scenes to load in your games and it only expects your micro game to only be in one scene
    /// </summary>


    public bool win = false; // Condition checked for the winning the micro game, set this in your game
    float maxGameTime = 0f; // The total time the micro game lasts
    float currentGameTime = 0f; // The timer counting down, defining how long the game lasts
    [SerializeField] string startingText = "Start Game!"; // The text that shows up at the start of the micro game, you can set this in the editor
    private bool gameActive = false;
    public UnityEvent OnEndMicroGameEvent = new UnityEvent();

    abstract public void OnStartMicroGame(); // Event function that is run when the game begins by the MacroGameManager
    abstract public void OnEndMicroGame(); // Event function that runs once the game is over, this is used for ending your game
    public float GetCurrentTime() { return currentGameTime; }
    public float GetMaxTime() { return maxGameTime; }
    public bool IsGameActive() { return gameActive; }
    public string GetStartingText() { return startingText; }

    // Used to update the timer stats based on the current state of the macro game
    public void InitalizeGameManagerData(float maxGameTime) {
        this.maxGameTime = maxGameTime; 
        currentGameTime = this.maxGameTime;
        win = false;
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive) {
            currentGameTime -= Time.deltaTime;
            if (currentGameTime <= 0) {
                OnEndMicroGame();
                OnEndMicroGameEvent.Invoke();
                gameActive = false;
            }
        }
    }
}
