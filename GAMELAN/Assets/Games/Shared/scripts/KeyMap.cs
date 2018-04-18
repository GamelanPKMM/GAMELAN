using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMap{
        private KeyCode[] key;
        public string name;
        private Action action;
        private float dTime;
        private float lastTime;
        public delegate void Action();
        public void checkInput(KeyCode input)
        {
            foreach (KeyCode k in key)
            {
                if (input.Equals(k) && Time.fixedTime >= lastTime + dTime)
                {
                    action();
                    lastTime = Time.fixedTime;
                    Debug.Log(name);
                    break;
                }
            }
        }
        public KeyMap(KeyCode[] k, string name, Action act, float time)
        {
            this.key = k;
            this.name = name;
            this.action = act;
            this.dTime = time;
            lastTime = Time.fixedTime;
        }
 
}
