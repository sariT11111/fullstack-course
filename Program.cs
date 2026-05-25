//EXERCISE 1: Null Safety
Console.WriteLine("=== Null Safety Demo ===");

string? region = null;

Console.WriteLine(region);

string displayRegion = region ?? "No Region Assigned";
Console.WriteLine(displayRegion);

region ??= "Addis Ababa";
Console.WriteLine(region);

Console.WriteLine(region?.ToUpper());

//student info
string  studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1500.50m;
DateTime enrollmentAt = DateTime.UtcNow;
string? campusRegion=null;

Console.WriteLine($"\nStudent Name: {studentName}");
Console.WriteLine($"Student ID: {studentId}");  
Console.WriteLine($"Enrollment Count: {enrollmentCount}");
Console.WriteLine($"Grant Amount: {grantAmount:C}");
Console.WriteLine($"Enrollment Date: {enrollmentAt}");
Console.WriteLine($"Campus Region: {campusRegion ?? "Not Assigned"}");
