using CodingAssignmentLib;
using System.Text.Json;

namespace CodingAssignmentTests;

[TestFixture]
public class JsonContentParserTests
{
    private JsonContentParser _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new JsonContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        var jsonContent = "[{\"Key\":\"key1\",\"Value\":\"value1\"},{\"Key\":\"key2\",\"Value\":\"value2\"}]";

        var result = _sut.Parse(jsonContent).ToList();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Key, Is.EqualTo("key1"));
        Assert.That(result[0].Value, Is.EqualTo("value1"));
        Assert.That(result[1].Key, Is.EqualTo("key2"));
        Assert.That(result[1].Value, Is.EqualTo("value2"));

        Console.WriteLine("JSON Parse_ReturnsData() passed");
    }

    [Test]
    public void Parse_ReturnsEmpty()
    {
        var jsonContent = "[]";

        var result = _sut.Parse(jsonContent);

        Assert.That(result, Is.Empty);

        Console.WriteLine("JSON Parse_ReturnsEmpty() passed");
    }

    [Test]
    public void Parse_InvalidJSON()
    {
        var jsonContent = "invalid json";

        Assert.Throws(Is.InstanceOf<JsonException>(), () => _sut.Parse(jsonContent));

        Console.WriteLine("JSON Parse_InvalidJSON() passed");
    }
} 