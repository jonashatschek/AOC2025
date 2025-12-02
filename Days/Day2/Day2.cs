using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class Day2 : IDay
{
    public int Day => 2;

    public void Run()
    {
        var input = File.ReadAllText("Days/Day2/testInput.txt");

        var productIdRanges = input.Split(',');
        BigInteger sumOfInvalidIds = 0;

        foreach (var range in productIdRanges)
        {
            var splitRange = range.Split('-');
            var firstId = BigInteger.Parse(splitRange[0]);
            var lastId = BigInteger.Parse(splitRange[1]);

            for (BigInteger i = firstId; i <= lastId; i++)
            {
                var productString = i.ToString();
                var productIdLength = productString.Length;

                if (productIdLength % 2 == 0)
                {
                    var half = productIdLength / 2;
                    BigInteger left = BigInteger.Parse(productString.Substring(0, half));
                    BigInteger right = BigInteger.Parse(productString.Substring(half));


                    if (left == right)
                    {
                        sumOfInvalidIds += i;
                    }
                }
            }
        }

        Console.WriteLine("=== Day 2 ===");

        // TODO: solve part 1
        Console.WriteLine($"{sumOfInvalidIds}");
        // TODO: solve part 2
    }
}
