using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelScript : KarapanSubScontroller {
    private GameObject child;
    void pausing() {
        gameObject.SetActive(true);
        if (basicGameControl.getIsUserInputAllowed())
        {
            child.SetActive(true);
        }
        else {
            child.SetActive(false);
        }
    }
    void playing() {
        gameObject.SetActive(false);
    }
    protected override void start()
    {
        base.start();
        gameControl.addEvent("Pausing", pausing);
        gameControl.addEvent("Playing", playing);
        child = transform.GetChild(0).gameObject;
        playing();
    }
}
