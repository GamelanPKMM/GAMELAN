using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameLoaderScript : MonoBehaviour {
    public string gameName;
    public MateriController mt;
    public void gotoMiniGames() {
        PlayerPrefs.SetString("minigame", gameName);
        SceneManager.LoadScene(gameName);
        AudioSource main = AudioController.instance.getAudioSource("MainMenu");
        main.Stop();
        Debug.Log(gameName);
    }

    public void click() {
        mt.setMateriPath(gameName);
        mt.startPreGameMateri(this);
    }
}
