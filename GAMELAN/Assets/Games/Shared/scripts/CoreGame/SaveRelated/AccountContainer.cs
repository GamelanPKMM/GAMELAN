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

    public static AccountContainer load() {
        string path;
        path = "file://" + Application.dataPath + "/SaveGame/SaveGame.xml";
        WWW file = new WWW(path);
        if (file != null)
        {
            while (!file.isDone) ;
            XmlSerializer serializer = new XmlSerializer(typeof(AccountContainer));
            StringReader s = new StringReader(file.text);
            return serializer.Deserialize(s) as AccountContainer;

        } else return new AccountContainer ();
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(AccountContainer));
        using (var stream = new FileStream(Application.dataPath + "/SaveGame/" + "SaveGame.xml", FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
