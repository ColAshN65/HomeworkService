using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities;

public class Teacher(
    Guid id, 
    PersonFullName name,
    IEnumerable<Homework> homeworks,
    IEnumerable<HomeworkResult> homeworkResults) : Person(id, name)
{
    public IReadOnlyCollection<Homework> Homeworks { get => _homeworks; }
    public IReadOnlyCollection<HomeworkResult> HomeWorkResults { get => _homeworkResults; }

    private HashSet<Homework> _homeworks = [.. homeworks];
    private HashSet<HomeworkResult> _homeworkResults = [.. homeworkResults];
}
