using System.Xml.Linq;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

// inheritance from IContentParser
public class XmlContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        // using LINQ to parse XML
        var root = XDocument.Parse(content).Root;
        
        if (root == null)
            return Enumerable.Empty<Data>();

        // get all elements with element tag <Data>
        var items = root.Elements("Data")
            .Select(element => new Data(
                element.Element("Key")?.Value ?? string.Empty,
                element.Element("Value")?.Value ?? string.Empty
            ));

        return items;
    }
} 