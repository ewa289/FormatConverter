using FormatConverter.Models;

namespace FormatConverter;

public class Converter
{
    public static People ConvertFile(string filePath)
    {
        try
        {
            string? line;
            string firstLetter; //Todo: better name
            string latestStartLetter = ""; //Todo: better name
            People people = new People();
            Person person = new Person();
            FamilyMember member = null;

            using StreamReader reader = new StreamReader(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                firstLetter = line.Substring(0, 1);
                switch (firstLetter)
                {
                    case "P":
                        latestStartLetter = firstLetter;
                        person = GetPerson(line);
                        people.Person.Add(person);

                        break;
                    case "T":
                        var phone = GetPhoneDetails(line);
                        if (latestStartLetter == "P" && person is not null)
                        {
                            person.Phone = phone;
                        }
                        else if (latestStartLetter == "F" && member is not null)
                        {
                            member.Phone = phone;
                        }
                        break;
                    case "A":
                        var address = GetAddress(line);
                        if (latestStartLetter == "P" && person is not null)
                        {
                            person.Address = address;
                        }
                        else if (latestStartLetter == "F" && member is not null)
                        {
                            member.Address = address;
                        }
                        break;
                    case "F":
                        latestStartLetter = firstLetter;
                        member = GetFamilyMember(line);

                        if (person is not null)
                            person.Family.Add(member);

                        break;
                    default:
                        break;
                }
            }

            return people;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to convert file.", ex);
        }

    }
    private static Address GetAddress(string line)
    {
        var firstIndex = line.IndexOf('|');
        var secondIndex = line.IndexOf('|', firstIndex + 1);
        var thirdIndex = line.IndexOf('|', secondIndex + 1);

        string city;
        string zipCode;

        var street = line.Substring(firstIndex + 1, secondIndex - 2);

        if (thirdIndex > 0)
        {
            city = line.Substring(secondIndex + 1, thirdIndex - secondIndex - 1);
            zipCode = thirdIndex > 0 ? line.Substring(thirdIndex + 1) : "";
        }
        else
        {
            city = line.Substring(secondIndex + 1);
            zipCode = "";
        }

        return new Address()
        {
            Street = street,
            City = city,
            ZipCode = zipCode
        };
    }

    private static Phone GetPhoneDetails(string line)
    {
        var firstIndex = line.IndexOf('|');
        var secondIndex = line.IndexOf('|', firstIndex + 1);

        var mobile = line.Substring(firstIndex + 1, secondIndex - 2);
        var landLine = line.Substring(secondIndex + 1);

        return new Phone()
        {
            Mobile = mobile,
            Landline = landLine,
        };
    }

    private static Person GetPerson(string line)
    {
        var firstIndex = line.IndexOf('|');
        var secondIndex = line.IndexOf('|', firstIndex + 1);

        var firstname = line.Substring(firstIndex + 1, secondIndex - 2);
        var lastname = line.Substring(secondIndex + 1);

        return new Person()
        {
            Firstname = firstname,
            Lastname = lastname,
        };

    }

    private static FamilyMember GetFamilyMember(string line)
    {
        var firstIndex = line.IndexOf('|');
        var secondIndex = line.IndexOf('|', firstIndex + 1);

        var name = line.Substring(firstIndex + 1, secondIndex - 2);
        var birthYear = line.Substring(secondIndex + 1);

        return new FamilyMember()
        {
            Name = name,
            BirthYear = birthYear
        };
    }
}
