using FormatConverter.Models;

namespace FormatConverter;

public class Converter
{
    public static People ConvertFile(string filePath)
    {
        try
        {
            string? line;
            var isPerson = false;
            var isFamily = false;
            var people = new People();
            Person person = null;
            FamilyMember member = null;

            using StreamReader reader = new StreamReader(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                switch (line.Substring(0, 1))
                {
                    case "P":
                        isPerson = true;
                        isFamily = false;
                        person = GetPerson(line);
                        people.Person.Add(person);

                        break;
                    case "T":
                        var phone = GetPhoneDetails(line);
                        if (isPerson && person is not null)
                        {
                            person.Phone = phone;
                        }
                        else if (isFamily && member is not null)
                        {
                            member.Phone = phone;
                        }
                        break;
                    case "A":
                        var address = GetAddress(line);
                        if (isPerson && person is not null)
                        {
                            person.Address = address;
                        }
                        else if (isFamily && member is not null)
                        {
                            member.Address = address;
                        }
                        break;
                    case "F":
                        isFamily = true;
                        isPerson = false;
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
        var parts = line.Split('|');
        var street = parts[1];
        string city;
        string zipCode;

        if (parts.Length > 3)
        {
            city = parts[2];
            zipCode = parts[3];
        }
        else
        {
            city = parts[2];
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
        var parts = line.Split('|');

        return new Phone()
        {
            Mobile = parts[1],
            Landline = parts[2],
        };
    }

    private static Person GetPerson(string line)
    {
        var parts = line.Split('|');
        
        return new Person()
        {
            Firstname = parts[1],
            Lastname = parts[2],
        };

    }

    private static FamilyMember GetFamilyMember(string line)
    {
        var parts = line.Split('|');
        
        return new FamilyMember()
        {
            Name = parts[1],
            BirthYear = parts[2]
        };
    }
}
