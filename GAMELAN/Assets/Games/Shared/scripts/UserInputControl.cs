using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputControl : SubController {
    public delegate void InputHandler();
    InputHandler inputHandler;
    private LinkedList<KeyMap> keyMap = new LinkedList<KeyMap>();
    public const float AlwaysPress = 0;
    public  const float SometimePress = 0.1F;
    public  const float SeldomtimePress = 0.15F;
    public  const float MoreSeldomtimePress = 0.2F;
    public const float second = 1F;

    void FixedUpdate() {
        if (Input.anyKey && basicGameControl.getIsUserInputAllowed())
        {
            inputHandler();
        }
    }

    void OnGUI() {
        
    }

     public void addKeyMap(KeyMap k) {
         this.keyMap.AddLast(k);
         this.inputHandler += k.checkInput;
     }
}
