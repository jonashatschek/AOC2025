param(
    [Parameter(Mandatory = $true)]
    [int]$Day
)

$dayPadded = $Day.ToString("0")
$dir = "Days/Day$dayPadded"

if (!(Test-Path $dir)) {
    New-Item -ItemType Directory -Path $dir | Out-Null
}

# Create test input file
$testInputFile = "$dir/testInput.txt"
if (!(Test-Path $testInputFile)) {
    New-Item -ItemType File -Path $testInputFile | Out-Null
}

# Create input file
$inputFile = "$dir/input.txt"
if (!(Test-Path $inputFile)) {
    New-Item -ItemType File -Path $inputFile | Out-Null
}

# Create DayXX.cs
$csFile = "$dir/Day$dayPadded.cs"
if (!(Test-Path $csFile)) {
    @"
public class Day$dayPadded : IDay
{
    public int Day => $Day;

    public void Run()
    {
        var input = File.ReadAllText("Days/Day$dayPadded/input.txt");

        Console.WriteLine("=== Day $dayPadded ===");

        // TODO: solve part 1
        Console.WriteLine($"Part 1: {}");

        // TODO: solve part 2
        Console.WriteLine($"Part 2: {}");
    }
}
"@ | Out-File $csFile -Encoding utf8
}

Write-Host "Created Day $dayPadded. Happy coding!"


#to use: run ./new-day.ps1 [day number], e.g. 3