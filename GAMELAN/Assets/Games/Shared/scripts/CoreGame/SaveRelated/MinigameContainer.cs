using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
[XmlRoot("MinigamesRoot")]
public class MinigameContainer {
    [XmlArray("Minigames")]
    [XmlArrayItem("MinigameItem")]
    public List<Minigame> minigames = new List<Minigame>();


    public static MinigameContainer loadMinigame()
    {
        TextAsset xmlLoad = Resources.Load("MiniGames") as TextAsset;
        XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
        StringReader reader = new StringReader(xmlLoad.text);
        return serializer.Deserialize(reader) as MinigameContainer;
    }
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(MinigameContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
