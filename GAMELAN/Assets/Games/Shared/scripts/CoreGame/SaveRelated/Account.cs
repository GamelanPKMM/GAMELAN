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
    public int getScore(string minigame) {
        foreach (MinigameSave save in minigameSave) {
            if (save.name.Equals(minigame)){
                return save.score;
            }
        }
        return -1;
    }
    public void setScore(string minigame, int score) {
        foreach (MinigameSave save in minigameSave)
        {
            if (save.name.Equals(minigame)){
                save.score = score;
                return;
            }
        }
    }
    public void setHighScore(string minigame, int score) {
        foreach (MinigameSave save in minigameSave)
        {
            if (save.name.Equals(minigame))
            {
                if (save.score < score) {
                    save.score = score;
                }
                return;
            }

        }
    }
}
