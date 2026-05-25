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
//EXERCISE 2: Financial Calculations(The Ministry Audit Failure)
//Legacy Implementation--the bug that caused audit failure
//using double caused the bug
Console.WriteLine("\n=== Legacy Implementation ===");

// Fixed implementation — exact financial math 
decimal grantPerStudent = 1999.99m; 
decimal totalAllocation = grantPerStudent * 100_000m; 
Console.WriteLine($"Total allocated (decimal): {totalAllocation}"); 
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");

//EXERCISE 3: Pipeline Data Corruption

var enrollmentRecord = new EnrollementRecord(
    "STU-001",
    "CS401",
 DateTime.UtcNow
);
Console.WriteLine(enrollmentRecord);
var corrected=enrollmentRecord with{CourseCode="CS-402"};
Console.WriteLine(corrected);
var duplicate=new EnrollementRecord(
    "STU-001",
    "CS401",
 enrollmentRecord.EnrolledAt
);
Console.WriteLine($"same data?{enrollmentRecord==duplicate}");
