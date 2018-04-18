using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanGameInput : KarapanSubScontroller {

    protected override void start()
    {
        base.start();
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.Q }, "DebugDecreaseLife", delegate() { if (gameControl.isDebugState())gameControl.lifeControl.decreaseLife(); }, UserInputControl.SeldomtimePress));
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.E }, "DebugIncreaseLife", delegate() { if (gameControl.isDebugState())gameControl.lifeControl.increaseLife(); }, UserInputControl.SeldomtimePress));
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.LeftArrow, KeyCode.A }, "MovePlayerLeft", delegate() { if (!gameControl.isPause() && gameControl.getGameState())gameControl.playerControl.registerMove(-1); }, UserInputControl.SometimePress));
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.RightArrow, KeyCode.D }, "MovePlayerRight", delegate() { if (!gameControl.isPause() && gameControl.getGameState())gameControl.playerControl.registerMove(1); }, UserInputControl.SometimePress));
  
    }
}
