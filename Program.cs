var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m }; 
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");


void PrintGradeReport(IEnumerable<IGradable> assessments) 
{ 
    Console.WriteLine("--- Grade Report ---"); 
    foreach (var item in assessments) 
    { 
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%"); 
    } 
} 
 
// Test it — one array holds two completely different types 
IGradable[] cohortAssessments = [ 
    new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 }, 
    new LabAssignment { Title = "Registration API", FunctionalityScore = 70m, CodeQualityScore = 30m } 
]; 
 
PrintGradeReport(cohortAssessments); 