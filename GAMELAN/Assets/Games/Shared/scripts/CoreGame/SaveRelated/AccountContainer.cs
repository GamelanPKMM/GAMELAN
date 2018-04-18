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

    public AccountContainer load() {
        string path;
        path = "file://" + Application.dataPath + "/" + "Savegame.xml";
        Debug.Log(path);
        WWW file = new WWW(path);
        while (!file.isDone) ;
        XmlSerializer serializer = new XmlSerializer(typeof(AccountContainer));
        //FileStream stream = new FileStream(path, FileMode.Open);
        StringReader s = new StringReader(file.text);
        Debug.Log(file.text);
        return serializer.Deserialize(s) as AccountContainer;
    }
}
