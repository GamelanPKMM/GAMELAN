using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("PenghargaanContainer")]
public class PenghargaanContainer {

    [XmlArray("PenghargaanArray")]
    [XmlArrayItem("Penghargaan")]
    public List<Penghargaan> penghargaans = new List<Penghargaan>();
    public static PenghargaanContainer self;
    public static PenghargaanContainer load() {
        try
        {
            if (self == null)
            {
                TextAsset xmlLoad = Resources.Load("Penghargaan/data") as TextAsset;
                XmlSerializer serializer = new XmlSerializer(typeof(PenghargaanContainer));
                StringReader reader = new StringReader(xmlLoad.text);
                Debug.Log("Load penghargaan success");
                PenghargaanContainer p = serializer.Deserialize(reader) as PenghargaanContainer;
                self = p;
            }
                return self; 
        }
        catch (Exception e)
        {
            Debug.Log("File penghargaan couldnt be found");
            PenghargaanContainer m = new PenghargaanContainer();
            return m;
        }
    }
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(PenghargaanContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
