using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanSubScontroller : SubController {
    public KarapanGameControl gameControl;

    protected override void instantiate<T>()
    {
        base.instantiate<T>();
        gameControl = GameObject.FindGameObjectWithTag("SpecificGameController").GetComponent<KarapanGameControl>();

    }
}
