namespace Westcoast_Education_Avalonia.Models;

public class Student : Person
{
       public Student()
    {
    }

    public Student(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    } 
}