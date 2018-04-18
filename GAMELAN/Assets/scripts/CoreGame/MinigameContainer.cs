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


    public static MinigameContainer loadQuestion(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
        FileStream stream = new FileStream(path, FileMode.Open);
        return serializer.Deserialize(stream) as MinigameContainer;
    }

    public void Save(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
