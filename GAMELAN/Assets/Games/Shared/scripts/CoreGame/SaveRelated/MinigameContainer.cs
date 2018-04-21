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
<<<<<<< HEAD
        if (self == null)
        {
            TextAsset xmlLoad = Resources.Load("MiniGames") as TextAsset;
            XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
            StringReader reader = new StringReader(xmlLoad.text);
            self =  serializer.Deserialize(reader) as MinigameContainer;
            return self;
        }
        else return self;
=======
        TextAsset xmlLoad = Resources.Load("MiniGames.xml") as TextAsset;
        XmlSerializer serializer = new XmlSerializer(typeof(MinigameContainer));
        StringReader reader = new StringReader(xmlLoad.text);
        return serializer.Deserialize(reader) as MinigameContainer;
>>>>>>> a50d40f22fab8510918aa8faade0c86b2682012d
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
