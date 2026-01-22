using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities;

public class Homework(
    Guid id,
    AvailableDateTime creationTime,
    AvailableDateTime deadline,
    Teacher teacher, 
    IEnumerable<StudentGroup> groups,
    string title,
    IEnumerable<Media> media,
    int attempts)
    : EntityBase(id)
{
    public AvailableDateTime CreationTime { get; private set; } = creationTime;
    public AvailableDateTime Deadline { get; private set; } = deadline;
    public Teacher Teacher { get; } = teacher;
    public IReadOnlyCollection<StudentGroup> Groups { get => _groups; }
    public string Title { get; private set; } = title;
    public IReadOnlyCollection<Media> Medias { get => _media; }
    public int Attempts { get; private set; } = attempts;

    private readonly HashSet<StudentGroup> _groups = [.. groups];
    private readonly HashSet<Media> _media = [.. media];
}
