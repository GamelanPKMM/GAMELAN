using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

//[XmlRoot("Question")]
public class Question
{
    [XmlAttribute ("Question")]
    public string question{get;set;}
    public string[] answers { get; set; }
    public int answer { get; set; }
	
}
