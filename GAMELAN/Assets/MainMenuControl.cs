using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour {
    List<Account> acc;
    public Dropdown savesDropdown;
    public Text inputNewSave;
	// Use this for initialization
	void Start () {
        acc = AccountContainer.load().accounts;
        restartOption();
	}
    void restartOption() {
        savesDropdown.ClearOptions();
        List<string> option = new List<string>();
        foreach (Account a in acc)
        {
            option.Add(a.name);
        }
        savesDropdown.AddOptions(option);
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
        }
        catch (System.Exception e)
        {

        }

    }
    public void newSaveGame() {
        AccountContainer acc = AccountContainer.self;
        acc.addNewSaveGame(inputNewSave.text);
        restartOption();
    }
    public void deleteSaveGame() {
        AccountContainer acc = AccountContainer.self;
        acc.deleteAccount(acc.accounts[savesDropdown.value].name);
        savesDropdown.value = 0;
        acc.currentAccount = null;
        restartOption();
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
}
