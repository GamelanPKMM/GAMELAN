using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System;

public class Penghargaan{
    [XmlAttribute("Penghargaan")]
    public string name;
    public string imageName;
    public string penjelasan;
    public Penghargaan() { }
    public Penghargaan(string name) { this.name = name; }
    public Penghargaan(string name, string imageName) : this(name) { this.imageName = imageName;  }
    public Penghargaan(string name, string imageName, string penjelasan) : this(name, imageName) { this.penjelasan = penjelasan; }
    public Image getImage() {
        try
        {
            return Resources.Load("Penghargaan/Gambar/" + imageName) as Image;
        }
        catch (Exception e) {
            Debug.Log("Coulnt load image from penghargaan " + name);
            return null;
        }
    }
}
