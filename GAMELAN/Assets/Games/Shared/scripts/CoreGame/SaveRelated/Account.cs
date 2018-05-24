using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class Account {
    [XmlAttribute("Account")]
    public string name;
    public List<MinigameSave> minigameSave = new List<MinigameSave>();
    public List<PenghargaanSave> penghargaans = new List<PenghargaanSave>(); 
    public Account() { }
    public Account(string name) {
        this.name = name;
        MinigameContainer mc = MinigameContainer.loadMinigame();
        foreach (Minigame m in mc.minigames) {
            minigameSave.Add(new MinigameSave(m));
        }
        PenghargaanContainer pc = PenghargaanContainer.load();
        foreach (Penghargaan p in pc.penghargaans) {
            penghargaans.Add(new PenghargaanSave(p));
        }
    }
    public int getScore(string minigame) {
        foreach (MinigameSave save in minigameSave) {
            if (save.name.Equals(minigame)) {
                return save.score;
            }
        }
        return -1;
    }
    public void setScore(string minigame, int score) {
        foreach (MinigameSave save in minigameSave)
        {
            if (save.name.Equals(minigame)) {
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
    public void updateNewGameSave(List<Minigame> minigame) {
        foreach (Minigame miniGame in minigame) {
            bool isExist = false;
            foreach (MinigameSave gameSave in minigameSave) {
                if (miniGame.name.Equals(gameSave.name)) {
                    isExist = true;
                }
            }
            if (!isExist) {
                minigameSave.Add(new MinigameSave(miniGame));
            }
        }
    }
    public void updateNewPenghargaanSave(List<Penghargaan> penghargaan) {
        foreach (Penghargaan p1 in penghargaan)
        {
            bool isExist = false;
            foreach (PenghargaanSave p2 in this.penghargaans)
            {
                if (p1.name.Equals(p2.name))
                {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                penghargaans.Add(new PenghargaanSave(p1));
            }
        }
    }
}
