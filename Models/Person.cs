namespace FormatConverter.Models;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public Phone Phone { get; set; }
    public List<FamilyMember> Family { get; set; }

    public Person()
    {
        Family = new List<FamilyMember>();
    }

}
