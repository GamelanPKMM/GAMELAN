using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class SubController : MonoBehaviour {
    protected BasicGameControl basicGameControl;
	// Use this for initialization
	void Start () {
        start();
	}
    void Awake()
    {
        instantiate<BasicGameControl>();
    }
    bool isName(string name) { 
        return name.Equals(this.name);
    }

    //this is called in Awake
    protected virtual void instantiate<T>() where T : BasicGameControl{
        basicGameControl = GameObject.FindGameObjectWithTag("SpecificGameController").GetComponent<T>();

    }
    // this is called in Start
    protected virtual void start() {
    }
}
