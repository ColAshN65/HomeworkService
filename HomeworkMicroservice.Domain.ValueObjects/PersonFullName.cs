using HomeworkMicroservice.Domain.ValueObjects.Base;
using System.Text;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class PersonFullName : ValueObject
{
    public string FirstName { get => _firstName.Name; }
    public string Surname { get => _surname.Name; }
    public string Patronymic { get => _patronymic.Name; }
    public string FullName
    {
        get
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_firstName);
            sb.Append(' ');
            sb.Append(_surname);
            sb.Append(' ');
            sb.Append(_patronymic);

            return sb.ToString();
        }
    }

    private readonly PersonName _firstName;
    private readonly PersonName _surname;
    private readonly PersonName _patronymic;

    public PersonFullName(string firstName, string surname, string patronymic)
    {
        _firstName = new PersonName(firstName);
        _surname = new PersonName(surname);
        _patronymic = new PersonName(patronymic);
    }

    public override bool Equals(ValueObject? other)
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
