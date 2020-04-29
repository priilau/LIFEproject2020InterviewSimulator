using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Dialogue
{
    public List<DialogueNode> Nodes;

    public Dialogue()
    {
        Nodes = new List<DialogueNode>();
    }
  
    public static Dialogue LoadDialogue(string path)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Dialogue));
        StreamReader reader = new StreamReader(path);

        Dialogue dia = (Dialogue)ser.Deserialize(reader);

        return dia;
    }
}