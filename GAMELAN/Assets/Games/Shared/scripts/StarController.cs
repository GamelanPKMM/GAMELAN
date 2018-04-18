using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : SubController {

    protected int starCount = 0;
    public int maksStar = 5;
    public int minStar = 0;
    protected override void start()
    {
        base.start();
        basicGameControl.addEvent("Reset", reset);
    }

    protected override void instantiate<T>()
    {
        base.instantiate<T>();
        basicGameControl.addNewEventType("GetStar");
        basicGameControl.addSubController("StarController", this);

    }

    void reset(){
        starCount = minStar;
    } 

    public int getStar() {
        return starCount;
    }

    public void starCatched() { 
        
    }
    public void increaseStar() {
        starCount += starCount < maksStar ? 1 : 0;
        basicGameControl.callEvent("GetStar");
    }
}
