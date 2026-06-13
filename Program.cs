// See https://aka.ms/new-console-template for more information
// double grantPerStudent = 1999.99;

// double totalStudents = 100_000;

// double totalBudget = grantPerStudent * totalStudents;


// Console.WriteLine($"Total budget (double): {totalBudget}");
// string studentName = "Abeba";

// int enrollmentCount = 3;


// // String interpolation  clean, readable

// Console.WriteLine($"Student: {studentName}, Courses: {enrollmentCount}");
// string name = "Abeba";       // Guaranteed non-null

// string? region = null;        // Explicitly nullable  the '?' is the contract


// // Without null check  compiler warning CS8602

// // Console.WriteLine(region.ToUpper()); // WARNING: possible null reference


// // With null-conditional operator

// Console.WriteLine(region?.ToUpper() ?? "NO REGION ASSIGNED");
// A student might not have a region assigned yet

// string? region = null;

// Safe access with a default

// string displayRegion = region ?? "Unassigned";

// Console.WriteLine($"Region: {displayRegion}");

// Output: Region: Unassigned

// Null-conditional: call method only if not null

// int? length = region?.Length;  // length is null, not a crash

// // Practical pattern: Console.ReadLine() returns string?

// string? input = Console.ReadLine();

// if (input is null)
// {
//     Console.WriteLine("No input provided.");
//     return;
// }

// // After the null check, 'input' is promoted to non-null string
// Console.WriteLine($"You entered: {input.ToUpper()}");



// Console.WriteLine("=== TMS Core Engine ===");


// string studentName = "Kidane";

// int courseCount = 5;


// Console.WriteLine($"Welcome, {studentName}. You are enrolled in {courseCount} courses.");


// // C# 12+ collection expression

// string[] courses = ["C# Essentials", "TypeScript", "ASP.NET Core"];

// Console.WriteLine($"First course: {courses[0]}");




// Collection expressions (C# 12+, available in C# 14)





List<Student> students =
[
    new() { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new() { Id = "S2", Name = "Kidane", Age = 25, GPA = 2.9m },
    new() { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.5m },
    new() { Id = "S4", Name = "Sara",  Age = 23, GPA = 1.8m },
    new() { Id = "S5", Name = "Kidus", Age = 21, GPA = 3.2m },
];

// Console.WriteLine("=== Students with GPA >= 3.5 ===\n");

// LINQ filter to get only high scorers


var categorizedStudents = students.Select(s => new
{
    s.Name,
    s.GPA,
    Performance = s.GPA switch
    {
        >= 3.7m => "Excellent",
        >= 3.0m => "Very Good",
        >= 2.0m => "Fair",
        _       => "Bad"
    }
}).ToList();

// Display the results
foreach (var s in categorizedStudents)
{
    Console.WriteLine($"Name: {s.Name,-8} | GPA: {s.GPA} | Performance: {s.Performance}");


    
}



var report = students.Select(s => new
{
    s.Name,
    s.GPA,
    s.Age,
    Track = ClassifyStudent(s)
}).ToList();

// Display results
foreach (var s in report)
{
    Console.WriteLine($"Name: {s.Name,-6} | Age: {s.Age} | GPA: {s.GPA} | Status: {s.Track}");
}

// Your Property Pattern Matching Method
string ClassifyStudent(Student student) => student switch
{
    { GPA: >= 3.5m, Age: < 22 } => "Young high achiever scholarship candidate",
    { GPA: >= 3.5m }            => "Honors student",
    { GPA: < 2.0m }             => "At risk assign mentor",
    _                           => "Standard track"
};
var topScorers = students.Where(s => s.GPA >= 3.5m).ToList();

// Display the results
foreach (var s in topScorers)
{
    Console.WriteLine($"Name: {s.Name} | GPA: {s.GPA}");
}



// Simulating a database call with Task.Delay
async Task<Student> FetchStudentAsync(string studentId)
{
    Console.WriteLine($"  Fetching student {studentId}...");
    await Task.Delay(500);  // Simulate 500ms database query
    return new Student { Id = studentId, Name = $"Student-{studentId}", Age = 22 };
}
// Using it
var student = await FetchStudentAsync("STU-001");
Console.WriteLine($"  Loaded: {student.Name}");


// Student Class Definition
