using FormatConverter;
using FormatConverter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Welcome to the format converter.");
//Console.WriteLine("Enter path of file to convert including filename:");

//var filePath = Console.ReadLine();

var filePath = @"C:\tmp\testFile.txt";
while (!File.Exists(filePath))
{
    Console.WriteLine("Could not find the file. Make sure the path and file exist!");
    Console.WriteLine("Enter path of file to convert including filename:");

    filePath = Console.ReadLine();
}

var people = Converter.ConvertFile(filePath);
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
Console.WriteLine(json);
