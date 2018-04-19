using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
[XmlRoot("QuestionBank")]
public class QuestionContainer {
    [XmlArray("Questions")]
    [XmlArrayItem ("Question")]
    public List<Question> question = new List<Question>();

    public static QuestionContainer loadQuestion(string path){
        path = "file://" + Application.dataPath + "/"+path;
        Debug.Log(path);
        WWW file = new WWW(path);
        while (!file.isDone) ;
        XmlSerializer serializer = new XmlSerializer(typeof(QuestionContainer));
        //FileStream stream = new FileStream(path, FileMode.Open);
        StringReader s = new StringReader(file.text);
        Debug.Log(file.text);
        return serializer.Deserialize(s) as QuestionContainer;
    }

    public void Save(string path) {
        var serializer = new XmlSerializer(typeof(QuestionContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
