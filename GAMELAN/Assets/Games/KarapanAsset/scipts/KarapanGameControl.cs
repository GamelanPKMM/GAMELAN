using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanGameControl : BasicGameControl {
    public KarapanLifeControl lifeControl;
    public KarapanSpeedControl speedControl;
    public KarapanPlayerControl playerControl;
    public ProgressControl progressControl;
    public UserInputControl userInputControl;
    protected override void instantiate<T>()
    {
 	    base.instantiate<KarapanGameControl>();
        base.name = "Karapan";
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
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Space }, "TogglePause", delegate() { togglePause(); }, 0.5F));
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Slash }, "DEBUG", delegate() { toggleDebug(); }, UserInputControl.SeldomtimePress));
        userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Equals }, "reset", delegate() { gameOver(); resetGame(); }, UserInputControl.SometimePress));
    }
    void Update() { }
}
