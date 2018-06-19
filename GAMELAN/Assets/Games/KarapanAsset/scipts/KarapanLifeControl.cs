using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanLifeControl : KarapanSubScontroller {
    public int live = 3;

    public int maxLifeCap = 3;

    protected override void start()
    {
        base.start();
        gameControl.addEvent("Reset", reset);
    }

    protected override void instantiate<T>()
    {
        base.instantiate<KarapanGameControl>();
        gameControl.addNewEventType("LifeDecrease");
        gameControl.addNewEventType("LifeIncrease");
    }

    void FixedUpdate() {
        if (gameControl.getGameState()) {
            if (live <= 0)
            {
                gameControl.gameOver();
            }
        }
    }

    public void decreaseLife() {
        if (live > 0)
        {
            live--;
            gameControl.callEvent("LifeDecrease");
        }
    }
    public void increaseLife() {
        if (live < maxLifeCap)
        {
            live++;
            gameControl.callEvent("LifeIncrease");
        }
    }

    public float getLife() { return live; }
    public void reset() {
        live = maxLifeCap;
    }
    

}
