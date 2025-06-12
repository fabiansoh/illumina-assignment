using System.Text.Json;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class JsonContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        // deserialise content string into JsonDocument
        var root = JsonDocument.Parse(content).RootElement;
        
        // assuming that we are always getting a json array in json files
        // need to cater for json object if required
        return root.EnumerateArray()
            .Select(element => new Data(
                element.GetProperty("Key").GetString() ?? string.Empty,
                element.GetProperty("Value").GetString() ?? string.Empty
            ))
            .ToList();
    }
}