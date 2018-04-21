using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoreGameInterface : MonoBehaviour {
    AccountContainer acc;
    string gameName;
    void Start() {
        acc = AccountContainer.load();
        gameName = PlayerPrefs.GetString("minigame");
        Debug.Log(gameName);
    }

    public void exitGame(int starNum) {
        save(starNum);
        PlayerPrefs.SetString("minigame", null);
        SceneManager.LoadScene("MAP");
    }

    public void save(int starNum)
    {
        acc.currentAccount.setHighScore(gameName, starNum);
        acc.saveGame(acc.currentAccount);
        acc.Save();
    }
}
