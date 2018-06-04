using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoreGameInterface : MonoBehaviour {
    AccountContainer acc;
    public static CoreGameInterface instance;
    string gameName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        acc = AccountContainer.self;
        loadGame();
    }

    public void loadGame() {
        gameName = PlayerPrefs.GetString("minigame");
        Debug.Log("Load Save : " + gameName + " Active");
    }

    public void exitGame(int starNum) {
        save(starNum);
        exitGame();
    }

    public void save(int starNum)
    {
        acc.currentAccount.setHighScore(gameName, starNum);
        acc.saveGame(acc.currentAccount);
        acc.Save();
    }
    public void exitGame() {
        Time.timeScale = 1;
        PlayerPrefs.SetString("minigame", null);
        SceneManager.LoadScene("MAP");
    }
}
