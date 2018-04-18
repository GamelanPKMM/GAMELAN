using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;

public class Minigame {
    [XmlAttribute ("Minigame")]
    public string name;
    public Minigame() { }
    public Minigame(string name) {
        this.name = name;
    }
}
