//Exercise 3 — Part 2: Course Capacity with the field Keyword 
// Legacy Pre-C# 14 Implementation (Verbose) 
var course = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};

Console.WriteLine(
    $"Course: {course.Title} (Capacity: {course.Capacity})");


// INVALID CAPACITY
try
{
    course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}


// INVALID TITLE
try
{
    course.Title = "";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}