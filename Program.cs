using FormatConverter;
using FormatConverter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

Console.WriteLine("Welcome to the format converter.");
Console.WriteLine("Enter path of file to convert including filename:");

var filePath = Console.ReadLine();
//var filePath = @"C:\tmp\testFile.txt";

while (!File.Exists(filePath))
{
    Console.WriteLine("Could not find the file. Make sure the path and file exist!");
    Console.WriteLine("Enter path of file to convert including filename:");

    filePath = Console.ReadLine();
}

var people = Converter.ConvertFile(filePath);

WriteToDisk(people, filePath);

void WriteToDisk(People people, string filePath)
{
    var peopleObject = new { people };

    var settings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        },
        Formatting = Formatting.Indented
    };
    var json = JsonConvert.SerializeObject(peopleObject, settings);
    //Console.WriteLine(json);

    try
    {
        var extensionIndex = filePath.IndexOf('.');
        var newFilePath = filePath.Substring(0, extensionIndex);

        using StreamWriter writer = new StreamWriter($"{newFilePath}.json");
        writer.Write(json);
    }
    catch (Exception ex)
    {

        throw new Exception("Failed to write to file.", ex);
    }
}