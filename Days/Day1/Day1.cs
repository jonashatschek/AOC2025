public class Day1 : IDay
{
    public int Day => 1;

    private const int MaxPosition = 100;
    public void Run()
    {
        var rotations = File.ReadAllLines("Days/Day1/testInput.txt");

        var startPosition = 50;
        var part1Password = 0;
        var part2Password = 0;


        foreach (var rotation in rotations)
        {
            var nextPosition = startPosition;
            var clicks = int.Parse(rotation[1..]);
            var direction = rotation[0];

            part2Password += clicks / MaxPosition;

            clicks %= MaxPosition;

            if (direction == 'R')
            {
                if (startPosition + clicks >= MaxPosition)
                {
                    nextPosition = startPosition + clicks - MaxPosition;

                    if (nextPosition != 0 && startPosition != 0)
                    {
                        part2Password++;
                    }

                }
                else
                {
                    nextPosition += clicks;
                }
            }
            else
            {
                if (startPosition - clicks < 0)
                {
                    nextPosition = MaxPosition - Math.Abs(startPosition - clicks);

                    if (nextPosition != 0 && startPosition != 0)
                    {
                        part2Password++;
                    }
                }
                else
                {
                    nextPosition -= clicks;
                }
            }

            if (nextPosition == 0)
            {
                part1Password++;
                part2Password++;
            }

            startPosition = nextPosition;
        }

        Console.WriteLine("=== Day 1 ===");

        // TODO: solve part 1
        Console.WriteLine($"{part1Password}");

        // TODO: solve part 2
        Console.WriteLine($"{part2Password}");
    }
}