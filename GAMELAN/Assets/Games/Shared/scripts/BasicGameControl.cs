using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicGameControl : SubController {
    public string name { set; get; }
    protected bool isPaused = false;
    protected bool gameState = false;
    protected bool isDebug = false;
    protected bool isFinish = false;
    protected bool isUserInputAllowed = true;

    public delegate void eventCall();
    private Dictionary<string, eventCall> events = new Dictionary<string, eventCall>();
    private Dictionary<string, SubController> subController = new Dictionary<string, SubController>();

    protected CoreGameInterface coreInterface;
    public bool isPause() { return isPaused; }
    public void togglePause() {
        if (gameState)
        {
            if (isPause())
            {
                unpauseGame();
            }
            else {
                pauseGame();
            }
        }
    }
    public void pauseGame() {
        isPaused = true;
        callEvent("Pausing");
    }
    public void unpauseGame() {
        isPaused = false;
        callEvent("Playing");
    }
    public void resetGame() { gameState = true; getEvent("Reset")(); allowUserInput(); }
    public void gameOver() { gameState = false; getEvent("GameOver")(); banUserInput(); }
    public bool getGameState() { return gameState; }
    protected void toggleDebug() { isDebug = !isDebug; if (isDebug) getEvent("Debug")(); }
    private bool getDebugState() { return isDebug; }
    public bool isDebugState() { return isDebug; } 
    public void FinishGame() {
        isFinish = true;
        gameOver();
        callEvent("Finish");

    }
    public virtual void exitGame() {
        callEvent("ExitGame");
        /*
        * get out from mini game to core game
        * */
    }
    public virtual void saveGame() { }
    public void toggleUserInput() {
        if (isUserInputAllowed)
        {
            banUserInput();
        }
        else allowUserInput();
    }
    public void allowUserInput() {
        isUserInputAllowed = true;
        callEvent("UserInputAllowed");
    }
    public void banUserInput() {
        isUserInputAllowed = false;
        callEvent("UserInputBanned");
    }
    public bool getIsUserInputAllowed() {
        return isUserInputAllowed;
    }
    public bool getIsFinish() { return isFinish; }
    public eventCall getEvent(string name){
        if (events.ContainsKey(name))
        {
            return events[name];
        }
        else return null;
    }
    // called on Awake
    protected override void instantiate<T>() {
        base.instantiate<T>();
        coreInterface = GetComponent<CoreGameInterface>();
        events.Add("Reset", delegate() { Debug.Log("Reset"); });
        events.Add("GameOver", delegate() { Debug.Log("GameOver"); });
        events.Add("Pausing", delegate() { Debug.Log("Pausing"); });
        events.Add("Playing", delegate() { Debug.Log("Playing"); });
        events.Add("Debug", delegate() { Debug.Log("Debug"); });
        events.Add("Finish", delegate() { Debug.Log("Finish"); });
        events.Add("ExitGame", delegate() { Debug.Log("ExitGame"); });
        events.Add("UserInputBanned", delegate(){Debug.Log("UserInputBanned");});
        events.Add("UserInputAllowed", delegate() { Debug.Log("UserInputAllowed"); });
        UnityEngine.Debug.Log("Instantiating Game Control Succes");
    }
    public void addEvent(string eventName, eventCall newEvent){
       
        events[eventName] += newEvent;
            
    }
    public void removeEvent(string eventName, eventCall removedEvent) {
        events[eventName] -= removedEvent;
    }

    public void addNewEventType(string eventName) {
        events.Add(eventName, delegate() { });
    }
    public void callEvent(string name) {
        events[name]();
    }
    public void addSubController(string name, SubController sub){
        this.subController.Add(name, sub);
    }
    public T SubController<T>(string name) where T : SubController {
        return (T)this.subController[name];
    }

}
