namespace Contacts.Domain;

public class Contact
{
    protected Contact() {}

    public Contact(string givenName, string surname, string email, string phoneNumber)
    {
        GivenName = givenName;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Guid Id { get; init; }
    public string GivenName { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;

    public void Update(string givenName, string surname, string email, string phoneNumber)
    {
        GivenName = givenName;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}