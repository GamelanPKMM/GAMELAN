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

    public static QuestionContainer loadQuestion(string path)
    {
        path = "file://" + Application.dataPath + "/Questions/" + path + ".xml";
        Debug.Log(path);
        WWW file = new WWW(path);
        while (!file.isDone) ;
        if (!file.text.Equals(""))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionContainer));
            StringReader s = new StringReader(file.text);
            Debug.Log(file.text);
            return serializer.Deserialize(s) as QuestionContainer;
        }
        else {
            QuestionContainer q = new QuestionContainer();
            q.Save(Application.dataPath + "/" + path);
            return q;
        }
    }

    public void Save(string path) {
        var serializer = new XmlSerializer(typeof(QuestionContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
