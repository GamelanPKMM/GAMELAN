using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class Account{
    [XmlAttribute("Account")]
    public string name;
    public List<MinigameSave> minigameSave = new List<MinigameSave>();
    public Account() { }
    public Account(string name) {
        this.name = name;
        MinigameContainer mc = MinigameContainer.loadMinigame();
        foreach (Minigame m in mc.minigames) {
            minigameSave.Add(new MinigameSave(m));
        }
    }
}
