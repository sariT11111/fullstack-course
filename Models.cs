public class Student
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public decimal GPA { get; set; }
}

public class Course
{
    public string Code { get; set; } = "";
    public string Title { get; set; } = "";
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
}

public record EnrollmentRecord(
    string StudentId,
    string CourseCode,
    DateTime EnrolledAt
);

public interface IGradable
{
    string Title { get; }
    decimal MaxScore { get; }
    decimal EarnedScore { get; }

    decimal GetPercentage();
}

public class Quiz : IGradable
{
    public string Title { get; set; } = "";
    public decimal MaxScore { get; set; }
    public decimal EarnedScore { get; set; }

    public decimal GetPercentage()
    {
        if (MaxScore == 0)
        {
            return 0;
        }

        return EarnedScore / MaxScore * 100;
    }
}

public class LabAssignment : IGradable
{
    public string Title { get; set; } = "";
    public decimal MaxScore { get; set; }
    public decimal EarnedScore { get; set; }

    public decimal GetPercentage()
    {
        if (MaxScore == 0)
        {
            return 0;
        }

        return EarnedScore / MaxScore * 100;
    }
}