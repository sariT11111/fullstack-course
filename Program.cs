Console.WriteLine("--- Exercise 3: Classes and Models ---");

Student student = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

Course course = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30,
    EnrolledCount = 0
};

EnrollmentRecord enrollment = new EnrollmentRecord(
    student.Id,
    course.Code,
    DateTime.UtcNow
);

Console.WriteLine($"Student: {student.Name} ({student.Id})");
Console.WriteLine($"Course: {course.Title} ({course.Code})");
Console.WriteLine($"Enrolled at: {enrollment.EnrolledAt:yyyy-MM-dd}");

Console.WriteLine();

Console.WriteLine("--- Exercise 3B: Interface Contracts ---");

IGradable quiz = new Quiz
{
    Title = "C# Basics Quiz",
    MaxScore = 10,
    EarnedScore = 8
};

IGradable lab = new LabAssignment
{
    Title = "TMS Models Lab",
    MaxScore = 100,
    EarnedScore = 92
};

Console.WriteLine($"{quiz.Title}: {quiz.GetPercentage():F2}%");
Console.WriteLine($"{lab.Title}: {lab.GetPercentage():F2}%");

Console.WriteLine();

Console.WriteLine("--- Exercise 4: Guard Clauses and Pattern Matching ---");

var service = new EnrollmentService();

var validStudent = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

var validCourse = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30,
    EnrolledCount = 0
};

var result = service.ProcessRegistration(validStudent, validCourse);

Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");

