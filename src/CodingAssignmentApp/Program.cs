// See https://aka.ms/new-console-template for more information

using System.IO.Abstractions;
using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

Console.WriteLine("Coding Assignment!");

do
{
    Console.WriteLine("\n---------------------------------------\n");
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t1 - Display");
    Console.WriteLine("\t2 - Search");
    Console.WriteLine("\t3 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            Display();
            break;
        case "2":
            Search();
            break;
        case "3":
            return;
        default:
            return;
    }
} while (true);

void Display()
{
    Console.WriteLine("Enter the name of the file to display its content:");

    var fileName = Console.ReadLine()!;
    var fileUtility = new FileUtility(new FileSystem());
    var parserFactory = new ContentParserFactory();
    
    try
    {
        var extension = fileUtility.GetExtension(fileName);
        // return appropriate parser based on file extension
        var parser = parserFactory.CreateParser(extension);
        // polymorphism - parse the file content using the appropriate parser
        var dataList = parser.Parse(fileUtility.GetContent(fileName));

        Console.WriteLine("Data:");
        foreach (var data in dataList)
        {
            Console.WriteLine($"Key:{data.Key} Value:{data.Value}");
        }
    }
    // broad exception handling for now
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void Search()
{
    Console.WriteLine("Enter the key to search.");
}