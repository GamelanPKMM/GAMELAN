using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour {
    List<Account> acc;
    public Dropdown savesDropdown;
    public Text inputNewSave;
    public GameObject SaveGameUI;
    public Text namePlayers;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
        PenghargaanContainer.load();
        PenghargaanController.load();
        AudioController.Load();
        acc = AccountContainer.load().accounts;
        AudioSource audio = AudioController.getInstance().registerSound("Audio/Intro insyaAllah fix", "MainMenu");
        audio.loop = true;
        audio.Play();
        restartOption();
        saveClose();

    }
    void restartOption() {
        savesDropdown.ClearOptions();
        List<string> option = new List<string>();
        foreach (Account a in acc)
        {
            option.Add(a.name);
        }
        savesDropdown.AddOptions(option);
        load();
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void load()
    {
        try { 
            AccountContainer acc = AccountContainer.self;
            acc.loadGame(acc.accounts[savesDropdown.value]);
            Debug.Log(acc.currentAccount.name);
            namePlayers.text = "HAI " + AccountContainer.self.currentAccount.name + " !";
        }
        catch (System.Exception e)
        {

        }

    }
    public void newSaveGame() {
        try
        {
            AccountContainer acc = AccountContainer.self;
            acc.addNewSaveGame(inputNewSave.text);
            acc.loadGame(inputNewSave.text);
            restartOption();
        }
        catch (System.Exception e)
        {

        }
    }
    public void deleteSaveGame() {
        try
        {
            AccountContainer acc = AccountContainer.self;
            acc.deleteAccount(acc.accounts[savesDropdown.value].name);
            savesDropdown.value = 0;
            acc.currentAccount = null;
            restartOption();
        }
        catch (System.Exception e)
        {

        }
    }

    public void quitGame() {
        AccountContainer.self.Save();
        Debug.Log("Game exiting");
        Application.Quit();
        Debug.Log("Game exited");
    }

    public void gotoMap() {
        if (AccountContainer.self.currentAccount != null)
        {
            SceneManager.LoadScene("MAP");
        }
    }

    public void savePlayer()
    {
        SaveGameUI.SetActive(true);
    }
    public void saveClose()
    {
        SaveGameUI.SetActive(false);
    }

    public void stopMusic() {
        AudioSource audio = AudioController.getInstance().getAudioSource("MainMenu");
        audio.Stop();
    }
}
