using System;

namespace Westcoast_Education_Avalonia.Models;

public class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string SocialSecurityNumber { get; set; } = "";
    public Address Address { get; set; } = new();

}
