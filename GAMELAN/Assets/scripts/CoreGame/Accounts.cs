using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
[XmlRoot("Account")]
public class Accounts{
    [XmlAttribute("Account")]
    public string name;
    public List<MinigameSave> minigameSave = new List<MinigameSave>();

}
