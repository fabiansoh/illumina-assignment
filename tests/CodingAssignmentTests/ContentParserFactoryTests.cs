using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;
using NUnit.Framework;

namespace CodingAssignmentTests;

[TestFixture]
public class ContentParserFactoryTests
{
    private ContentParserFactory _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new ContentParserFactory();
    }

    [Test]
    public void CreateParserCsvExtensionReturnsCsvParser()
    {
        var parser = _factory.CreateParser(".csv");

        Assert.That(parser, Is.InstanceOf<CsvContentParser>());
    }

    [Test]
    public void CreateParserJsonExtensionReturnsJsonParser()
    {
        var parser = _factory.CreateParser(".json");

        Assert.That(parser, Is.InstanceOf<JsonContentParser>());
    }

    [Test]
    public void CreateParserXmlExtensionReturnsXmlParser()
    {
        var parser = _factory.CreateParser(".xml");

        Assert.That(parser, Is.InstanceOf<XmlContentParser>());
    }

    [Test]
    public void CreateParserUnsupportedExtensionThrowsError()
    {
        Assert.Throws<ArgumentException>(() => _factory.CreateParser(".txt"));
    }
} 