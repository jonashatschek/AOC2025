using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class Day2 : IDay
{
    public int Day => 2;

    public void Run()
    {
        var productIdRanges = File.ReadAllText("Days/Day2/testInput.txt").Split(',');

        BigInteger sumOfInvalidIds = 0;
        BigInteger updatedSumOfInvalidIds = 0;

        var twoBlockRepeatRegex = new Regex(@"^(\d+)\1$");
        var nBlockRepeatRegex = new Regex(@"\b(\d+)\1+\b");

        foreach (var range in productIdRanges)
        {
            var splitRange = range.Split('-');
            var firstId = BigInteger.Parse(splitRange[0]);
            var lastId = BigInteger.Parse(splitRange[1]);

            for (BigInteger i = firstId; i <= lastId; i++)
            {
                var productString = i.ToString();

                //p1
                if (twoBlockRepeatRegex.IsMatch(productString))
                {
                    sumOfInvalidIds += i;
                }

                //p2
                if (nBlockRepeatRegex.IsMatch(productString))
                {
                    updatedSumOfInvalidIds += i;
                }
            }
        }

        Console.WriteLine("=== Day 2 ===");

        // TODO: solve part 1
        Console.WriteLine($"Part 1: {sumOfInvalidIds}");

        // TODO: solve part 2
        Console.WriteLine($"Part 2: {updatedSumOfInvalidIds}");
    }

}