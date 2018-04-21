using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameLoaderScript : MonoBehaviour {
    public string gameName;

    public void gotoMiniGames() {
        SceneManager.LoadScene(gameName);
        PlayerPrefs.SetString("minigame", gameName);
    }
}
