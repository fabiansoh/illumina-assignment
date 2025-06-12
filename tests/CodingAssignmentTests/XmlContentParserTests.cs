using CodingAssignmentLib;
using NUnit.Framework;

namespace CodingAssignmentTests;

[TestFixture]
public class XmlContentParserTests
{
    private XmlContentParser _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new XmlContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        var xmlContent = @"
        <Datas>
            <Data>
                <Key>TestKey1</Key>
                <Value>TestValue1</Value>
            </Data>
            <Data>
                <Key>TestKey2</Key>
                <Value>TestValue2</Value>
            </Data>
        </Datas>";

        var result = _sut.Parse(xmlContent).ToList();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Key, Is.EqualTo("TestKey1"));
        Assert.That(result[0].Value, Is.EqualTo("TestValue1"));
        Assert.That(result[1].Key, Is.EqualTo("TestKey2"));
        Assert.That(result[1].Value, Is.EqualTo("TestValue2"));

        Console.WriteLine("XML Parse_ReturnsData() passed");
    }

    [Test]
    public void Parse_ReturnsEmpty()
    {
        var xmlContent = "<root></root>";

        var result = _sut.Parse(xmlContent);

        Assert.That(result, Is.Empty);

        Console.WriteLine("XML Parse_ReturnsEmpty() passed");
    }

    [Test]
    public void Parse_InvalidXML()
    {
        var xmlContent = "invalid xml";

        Assert.Throws<System.Xml.XmlException>(() => _sut.Parse(xmlContent));

        Console.WriteLine("XML Parse_InvalidXML() passed");
    }
} 