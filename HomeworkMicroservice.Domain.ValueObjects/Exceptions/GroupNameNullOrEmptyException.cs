using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkMicroservice.Domain.ValueObjects.Exceptions;

public class GroupNameNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Group name cannot be null or empty";
}
