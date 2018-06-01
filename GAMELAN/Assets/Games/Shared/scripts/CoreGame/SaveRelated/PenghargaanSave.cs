using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;

public class PenghargaanSave{
    public string name;
    public bool isEarned;
    public PenghargaanSave(Penghargaan p) {
        this.name = p.name;
    }
    public PenghargaanSave() { }
}
