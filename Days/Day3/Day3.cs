using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;

public class Day3 : IDay
{
    public int Day => 3;

    public void Run()
    {
        var solvePart1 = GetJoltageSum(2);

        var solvePart2 = GetJoltageSum(12);

        Console.WriteLine("=== Day 3 ===");

        // TODO: solve part 1
        Console.WriteLine($"Part 1: {solvePart1}");

        // TODO: solve part 2
        Console.WriteLine($"Part 2: {solvePart2}");
    }

    public BigInteger GetJoltageSum(int batteriesNeeded)
    {
        var banks = File.ReadAllLines("Days/Day3/Testinput.txt");
        BigInteger sumOfJoltage = 0;
        foreach (var bank in banks)
        {

            var foundBatteries = 0;
            var batteriesLeft = batteriesNeeded;
            var batteries = bank.Select(x => x - '0').ToArray();
            var nextIndex = 0;
            var largestJoltage = new List<char>();

            while (foundBatteries < batteriesNeeded)
            {

                var indexOfLargest = 0;
                var start = nextIndex;
                var end = batteries.Length - batteriesLeft;
                var battery = 0;

                for (int i = start; i < end + 1; i++)
                {
                    var batteryJoltage = bank[i];


                    if (batteryJoltage > battery)
                    {
                        indexOfLargest = i;
                        battery = batteryJoltage;
                    }

                }

                largestJoltage.Add((char)battery);
                nextIndex = indexOfLargest + 1;

                foundBatteries++;
                batteriesLeft = batteriesNeeded - foundBatteries;
            }

            sumOfJoltage += BigInteger.Parse(string.Join("", largestJoltage.Select(i => i)));

        }

        return sumOfJoltage;
    }

}
