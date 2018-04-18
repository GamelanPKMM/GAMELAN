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
        path = "file://" + Application.dataPath + "/"+ path;
        WWW file = new WWW(path);
        if (file == null) {
            Application.Quit();
        }
        while (!file.isDone) ;
        XmlSerializer serializer = new XmlSerializer(typeof(QuestionContainer));
        StringReader s = new StringReader(file.text);
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
