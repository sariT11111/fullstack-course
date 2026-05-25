Console.WriteLine("=== Null Safety Demo ===");

string? region = null;

Console.WriteLine(region);

string displayRegion = region ?? "No Region Assigned";

Console.WriteLine(displayRegion);

region ??= "Addis Ababa";

Console.WriteLine(region);

Console.WriteLine(region?.ToUpper());