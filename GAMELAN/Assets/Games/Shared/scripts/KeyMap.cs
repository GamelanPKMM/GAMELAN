using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMap{
        private KeyCode[] key;
        public string name;
        private Action action;
        private CheckMethod check;
        private float dTime;
        private float lastTime;
        public delegate void Action();
        public delegate bool CheckMethod(KeyCode k);
        public void checkInput()
        {
            foreach (KeyCode k in key)
            {
                if (check(k) && Time.fixedTime >= lastTime + dTime)
                {
                    action();
                    lastTime = Time.fixedTime;
                    Debug.Log(name);
                    break;
                }
            }
        }
        public KeyMap(KeyCode[] k, string name, Action act, CheckMethod check,float time)
        {
            this.key = k;
            this.name = name;
            this.action = act;
            this.dTime = time;
            this.check = check;
            lastTime = Time.fixedTime;
        }
 
}
