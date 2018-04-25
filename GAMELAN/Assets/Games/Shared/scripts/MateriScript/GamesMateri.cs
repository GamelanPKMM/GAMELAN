using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot ("MateriGame")]
public class GamesMateri{
    [XmlArrayItem("Materis")]
    [XmlArrayItem("Materi")]
    public List<Materi> materis = new List<Materi>();

    public static GamesMateri load(string path) {
        try
        {
            TextAsset xmlLoad = Resources.Load("Materi/Data/" + path) as TextAsset;
            XmlSerializer serializer = new XmlSerializer(typeof(GamesMateri));
            StringReader reader = new StringReader(xmlLoad.text);
            Debug.Log("Load " + path + "success");
            return serializer.Deserialize(reader) as GamesMateri;
        }
        catch (Exception e) {
            Debug.Log("File Materi/Data/" + path + " couldnt be found");
            GamesMateri m = new GamesMateri();
            return m;
        }
        
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
