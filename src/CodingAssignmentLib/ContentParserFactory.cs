using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class ContentParserFactory
{
    public IContentParser CreateParser(string fileExtension)
    {
        string extension = fileExtension.ToLower();
        
        if (extension == ".csv")
        {
            return new CsvContentParser();
        }
        else if (extension == ".json")
        {
            return new JsonContentParser();
        }
        else if (extension == ".xml")
        {
            return new XmlContentParser();
        }
        else
        {
            throw new ArgumentException($"Unsupported file extension: {fileExtension}");
        }
    }
}