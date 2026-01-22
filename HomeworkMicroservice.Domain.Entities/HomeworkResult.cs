using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities;

public class HomeworkResult(
    Guid id,
    Homework homework,
    Student student,
    AvailableDateTime updateTime,
    string result,
    HomeWorkState state,
    string comment)
    : EntityBase(id)
{ 
    public Homework Homework { get; } = homework;
    public Student Student { get; } = student;
    public AvailableDateTime UpdateTime { get; private set; }  = updateTime;
    public string Result { get; private set; } = result;
    public HomeWorkState State { get; private set; } = state;
    public string Comment { get; private set; } = comment;
}
