using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour {
     float height = 150f;
     static private string text = "Unity Console v1.4.567\n";
     Vector2 scrollPosition = new Vector2(0,0);
     void OnGUI() {
         scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width (Screen.width), GUILayout.Height(height));
         GUILayout.TextArea(text, GUILayout.MinHeight(height));
         GUILayout.EndScrollView();
     }
     
     static public void Add(string line) {
         text = text + line + "\n";
     }
 
}
