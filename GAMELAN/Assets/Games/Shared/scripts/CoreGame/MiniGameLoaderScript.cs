using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameLoaderScript : MonoBehaviour {
    public string gameName;
    public MateriController mt;
    public void gotoMiniGames() {
        PlayerPrefs.SetString("minigame", gameName);
        CloudSceneChanger.moveTo(gameName);
        //SceneManager.LoadScene(gameName);
        if (!gameName.Equals("MAIN"))
        {
            AudioSource main = AudioController.instance.getAudioSource("MainMenu");
            main.Stop();
        }
        Debug.Log(gameName);
    }

    public void click() {
        mt.setMateriPath(gameName);
        mt.startPreGameMateri(this);
    }
}
