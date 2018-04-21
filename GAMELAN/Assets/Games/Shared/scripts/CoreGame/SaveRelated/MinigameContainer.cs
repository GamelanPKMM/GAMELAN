using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
[XmlRoot("MinigamesRoot")]
public class MinigameContainer {
    [XmlArray("Minigames")]
    [XmlArrayItem("Minigame")]
    public List<Minigame> minigames = new List<Minigame>();
    public static MinigameContainer self;

    public static MinigameContainer loadMinigame()
    {
        if (self == null)
        {
            TextAsset xmlLoad = Resources.Load("MiniGames") as TextAsset;
            XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
            StringReader reader = new StringReader(xmlLoad.text);
            self =  serializer.Deserialize(reader) as MinigameContainer;
            return self;
        }
        else return self;
    }
    //this is deprecated so dont use it
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(MinigameContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
