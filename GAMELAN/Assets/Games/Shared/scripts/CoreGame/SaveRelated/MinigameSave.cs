using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;

public class MinigameSave : Minigame {

    public int score;
    public MinigameSave() { }
    public MinigameSave(Minigame m) {
        this.name = m.name;
        score = 0;
    }
    public void setScore(int score){
        this.score = score < 0 ? 0 : score > 5 ? 5 : score;
    }

    public int getScore() { return score; }
}
