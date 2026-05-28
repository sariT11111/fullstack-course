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

//Exercise 5: Collections and LINQ
Console.WriteLine();

Console.WriteLine("--- Exercise 5: Collections and LINQ ---");

List<Student> students = [
    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
    new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
    new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
    new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
];

var leaderboard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine($"Found {leaderboard.Count} Honors Students:");

foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}

decimal averageGpa = students.Average(s => s.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

var standingGroups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    >= 2.0m => "Probation",
    _ => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing Report ---");

foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key} ({group.Count()}):");

    foreach (var s in group)
    {
        Console.WriteLine($"   {s.Name} - GPA: {s.GPA}");
    }
}

string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];
string[] allCourses = [..backendCourses, ..frontendCourses, "Capstone"];

Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");

//session 3-Exercise 6: Async and Await
Console.WriteLine();

Console.WriteLine("--- Exercise 6: Async and Await ---");

var sw = System.Diagnostics.Stopwatch.StartNew();

for (int i = 0; i < 5; i++)
{
    System.Threading.Thread.Sleep(300);
}

Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");

sw.Restart();

for (int i = 0; i < 5; i++)
{
    await Task.Delay(300);
}

Console.WriteLine($"Async sequential:    {sw.ElapsedMilliseconds}ms");

sw.Restart();

var delayTasks = Enumerable.Range(0, 5)
    .Select(_ => Task.Delay(300));

await Task.WhenAll(delayTasks);

Console.WriteLine($"Async parallel:      {sw.ElapsedMilliseconds}ms");

Console.WriteLine();

Console.WriteLine("--- Exercise 6: Parallel Student and Course Loading ---");

sw.Restart();

string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];

var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));

Student[] loadedStudents = await Task.WhenAll(studentTasks);
Course[] loadedCourses = await Task.WhenAll(courseTasks);

Console.WriteLine($"\nLoaded {loadedStudents.Length} students and {loadedCourses.Length} courses in {sw.ElapsedMilliseconds}ms");

foreach (var s in loadedStudents)
{
    Console.WriteLine($"   {s.Name} - GPA: {s.GPA}");
}

async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($"   Fetching {id}...");

    await Task.Delay(300);

    return new Student
    {
        Id = id,
        Name = $"Student-{id}",
        Age = 20,
        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

async Task<Course> FetchCourseAsync(string code)
{
    Console.WriteLine($"   Fetching course {code}...");

    await Task.Delay(200);

    return new Course
    {
        Code = code,
        Title = $"Course-{code}",
        Capacity = code switch
        {
            "CRS-101" => 2,
            "CRS-201" => 30,
            "CRS-301" => 15,
            _ => 25
        }
    };
}
//session 3-Exercise 6 part B: TMS Enrollment Engine
Console.WriteLine();

Console.WriteLine("--- Exercise 6 Part B: TMS Enrollment Engine ---");

var enrollCourse = new Course
{
    Code = "CRS-101",
    Title = "C# Mastery",
    Capacity = 2,
    EnrolledCount = 0
};

var enrollService = new EnrollmentService();

var enrollments = new List<EnrollmentRecord>();
var failures = new List<string>();

sw.Restart();

foreach (var loadedStudent in loadedStudents)
{
    try
    {
        var record = enrollService.ProcessRegistration(loadedStudent, enrollCourse);

        enrollCourse.EnrolledCount++;
        enrollments.Add(record);

        Console.WriteLine($"   Enrolled: {loadedStudent.Name}");
    }
    catch (InvalidOperationException ex)
    {
        failures.Add($"{loadedStudent.Name}: {ex.Message}");
        Console.WriteLine($"   Rejected: {loadedStudent.Name} - {ex.Message}");
    }
}
//Exercise 7: Custom Exceptions
Console.WriteLine();

Console.WriteLine("--- Exercise 7: Custom Exceptions ---");

try
{
    var overflowCourse = new Course
    {
        Code = "CRS-999",
        Title = "Overflow Test",
        Capacity = 0,
        EnrolledCount = 0
    };

    enrollService.ProcessRegistration(
        new Student
        {
            Id = "S99",
            Name = "Test",
            Age = 20,
            GPA = 3.0m
        },
        overflowCourse
    );
}
catch (CapacityReachedException ex)
{
    Console.WriteLine("Domain exception caught:");
    Console.WriteLine($"   Course: {ex.CourseCode}");
    Console.WriteLine($"   Message: {ex.Message}");
}

//Exercise 7B: Enrollment Summary Report.
sw.Stop();

decimal classAverage = loadedStudents.Length > 0
    ? loadedStudents.Average(s => s.GPA)
    : 0m;

Console.WriteLine();

Console.WriteLine("========== ENROLLMENT SUMMARY ==========");
Console.WriteLine($"Total students loaded:       {loadedStudents.Length}");
Console.WriteLine($"Successful enrollments:      {enrollments.Count}");
Console.WriteLine($"Failed enrollments:          {failures.Count}");
Console.WriteLine($"Class average GPA:           {classAverage:F2}");
Console.WriteLine($"Total elapsed time:          {sw.ElapsedMilliseconds}ms");

if (failures.Count > 0)
{
    Console.WriteLine();

    Console.WriteLine("--- Failure Details ---");

    foreach (var failure in failures)
    {
        Console.WriteLine($"   {failure}");
    }
}

Console.WriteLine("========================================");
