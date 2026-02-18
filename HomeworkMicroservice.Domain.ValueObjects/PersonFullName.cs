using HomeworkMicroservice.Domain.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;
using System.Text;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class PersonFullName : ValueObject<string>
{
    public string FirstName { get => _firstName.Value; }
    public string Surname { get => _surname.Value; }
    public string Patronymic { get => _patronymic.Value; }

    public override string Value { get; }

    private readonly PersonName _firstName;
    private readonly PersonName _surname;
    private readonly PersonName _patronymic;

    /// <exception cref="PersonNameNullOrEmptyException"></exception>
    public PersonFullName(string firstName, string surname, string patronymic)
    {
        _firstName = new PersonName(firstName);
        _surname = new PersonName(surname);
        _patronymic = new PersonName(patronymic);

        StringBuilder sb = new();

        sb.Append(_firstName);
        sb.Append(' ');
        sb.Append(_surname);
        sb.Append(' ');
        sb.Append(_patronymic);

        Value = sb.ToString();
    }

    public override bool Equals(IValueObject? other)
    {
        if (other is not PersonFullName personFullName)
            return false;

        if (!Surname.Equals(personFullName.Surname))
            return false;

        if (!FirstName.Equals(personFullName.FirstName))
            return false;

        if (!Patronymic.Equals(personFullName.Patronymic))
            return false;

        return true;
    }
}
