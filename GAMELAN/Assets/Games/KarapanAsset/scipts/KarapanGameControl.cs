using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanGameControl : BasicGameControl {
    public KarapanLifeControl lifeControl;
    public KarapanSpeedControl speedControl;
    public KarapanPlayerControl playerControl;
    public ProgressControl progressControl;
    public UserInputControl userInputControl;
    public string Name;

    protected override void instantiate<T>()
    {
 	    base.instantiate<KarapanGameControl>();
        base.name = Name;
        userInputControl = gameObject.GetComponent<UserInputControl>();
        playerControl = GameObject.Find("Player").GetComponent<KarapanPlayerControl>();

        lifeControl = gameObject.GetComponent<KarapanLifeControl>();
        speedControl = gameObject.GetComponent<KarapanSpeedControl>();
        progressControl = gameObject.GetComponent<ProgressControl>();
        playerControl = GameObject.Find("Player").GetComponent<KarapanPlayerControl>();
        addSubController("LifeControl", lifeControl);
        addSubController("SpeedControl", speedControl);
        addSubController("PlayerControl", playerControl);
        addSubController("ProgressControl", progressControl);
        addSubController("UserInputControl", userInputControl);

        UnityEngine.Debug.Log(userInputControl);
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Space }, "TogglePause", delegate() { togglePause(); }, Input.GetKeyDown, 0.75F));
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Slash }, "DEBUG", delegate() { toggleDebug(); }, Input.GetKeyDown, UserInputControl.SeldomtimePress));
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Equals }, "reset", delegate() { gameOver(); resetGame(); }, Input.GetKeyDown, UserInputControl.SometimePress));
        AccountContainer.load();
    }
    void Update() { }
    public override void exitGame()
    {
        base.exitGame();
        Debug.Log("Exitting");
        coreInterface.exitGame(basicGameControl.SubController<StarController>("StarController").getStar());
        
    }
    public override void saveGame()
    {
        
            coreInterface.save(SubController<StarController>("StarController").getStar());
            Debug.Log("Saved");
        
    }
}
