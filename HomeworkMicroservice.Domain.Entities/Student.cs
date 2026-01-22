using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities;

public class Student(
    Guid id,
    PersonFullName name,
    IEnumerable<StudentGroup> groups,
    IEnumerable<Homework> homeworks,
    IEnumerable<HomeworkResult> homeworkResults)
    : Person(id, name)
{
    public IReadOnlyCollection<StudentGroup> Groups { get => _groups; }
    public IReadOnlyCollection<Homework> Homeworks { get => _homeworks; }
    public IReadOnlyCollection<HomeworkResult> HomeWorkResults { get => _homeworkResults; }

    private HashSet<StudentGroup> _groups = [.. groups];
    private HashSet<Homework> _homeworks = [.. homeworks];
    private HashSet<HomeworkResult> _homeworkResults = [.. homeworkResults];
}
