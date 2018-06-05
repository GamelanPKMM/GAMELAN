using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("AccountContainer")]
public class AccountContainer {
    [XmlArray("Accounts")]
    [XmlArrayItem("Account")]
    public List<Account> accounts = new List<Account>();
    public static AccountContainer self;
    public Account currentAccount;
    public static AccountContainer load() {
        if (self == null)
        {
            checkDirectory();
            string path;
            path = "file://" + Application.dataPath + "/SaveGame/SaveGame.xml";
            WWW file = new WWW(path);
            if (!file.text.Equals(""))
            {
                while (!file.isDone) ;
                XmlSerializer serializer = new XmlSerializer(typeof(AccountContainer));
                StringReader s = new StringReader(file.text);
                self = serializer.Deserialize(s) as AccountContainer;
                foreach (Account a in self.accounts) {
                    a.updateNewGameSave(MinigameContainer.loadMinigame().minigames);
                    a.updateNewPenghargaanSave(PenghargaanContainer.load().penghargaans);
                    self.Save();
                }
                return self;

            }
            else
            {
                AccountContainer a = new AccountContainer();
                a.Save();
                return a;
            }
        }
        else return self;
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(AccountContainer));
        checkDirectory();
        using (var stream = new FileStream(Application.dataPath + "/SaveGame/" + "SaveGame.xml", FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }


    public void loadGame(Account account) {
        currentAccount = account;
    }
    public void loadGame(string name) {
        try
        {
            List<Account> acc = self.accounts;
            foreach (Account a in acc)
            {
                if (a.name.Equals(name))
                {
                    currentAccount = a;
                    return;
                }
            }
        }
        catch (System.Exception e)
        {

        }
    }
    public void saveGame(Account account) {
        try
        {
            List<Account> acc = self.accounts;
            for (int i = 0; i < acc.Count; i++)
            {
                if (acc[i].name.Equals(account.name))
                {

                    acc[i] = account;
                    self.Save();
                    return;
                }
            }
        }
        catch (System.Exception e) {
            Debug.Log("Failed to save Acount");

        }

    }
    public string addNewSaveGame(string name) {
        try
        {
            List<Account> acc = self.accounts;
            foreach (Account a in acc)
            {
                if (a.name.Equals(name))
                {
                    return "Account already exists";
                }
            }
            self.accounts.Add(new Account(name));
            self.Save();
            return "success";
        }
        catch (System.Exception e)
        {
            return "failed to add new";
        }
    }
    public void deleteAccount(string name) {
        try
         {
            List<Account> acc = self.accounts;
            int delete = 0;
            for (int i = 0; i < acc.Count; i++)
            {
                if (acc[i].name.Equals(name))
                {
                    delete = i;
                    break;
                }
             }
             acc.RemoveAt(delete);
             self.currentAccount = null;
             self.Save();
        }
        catch (System.Exception e)
        {
            Debug.Log("Failed to delete Acount");
        }
    }
    public List<Account> getAllSaveGame() {
       try
       {
           return self.accounts;
        }
        catch (System.Exception e)
        {
            return null;
        }
    }

    public static void checkDirectory() {
        if (!Directory.Exists(Application.dataPath+"/SaveGame"))
        {
            Directory.CreateDirectory(Application.dataPath+"/SaveGame");
        }
    }
}
