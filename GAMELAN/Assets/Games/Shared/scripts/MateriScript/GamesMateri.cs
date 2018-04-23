using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot ("MateriGame")]
public class GamesMateri{
    [XmlArrayItem("Materi")]
    public List<Materi> materis = new List<Materi>();

    public static GamesMateri load(string path) {
        TextAsset xmlLoad = Resources.Load("Materi/Data/"+path) as TextAsset;
        XmlSerializer serializer = new XmlSerializer(typeof(GamesMateri));
        StringReader reader = new StringReader(xmlLoad.text);
        return serializer.Deserialize(reader) as GamesMateri;
        
    }
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(GamesMateri));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
