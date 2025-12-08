public class Day4 : IDay
{
    public int Day => 4;
    public static readonly List<int[]> Directions = [[0, 1], [1, 1], [1, 0], [1, -1], [0, -1], [-1, -1], [-1, 0], [-1, 1]]; //n, ne, e, se, s, sw, w, nw

    public void Run()
    {
        var input = File.ReadAllLines("Days/Day4/testInput.txt").ToList();

        var part1Result = SolvePart1(input);
        var part2Result = SolvePart2(input);

        Console.WriteLine("=== Day 4 ===");
        Console.WriteLine($"Part 1: {part1Result}");
        Console.WriteLine($"Part 2: {part2Result}");
    }

    public int SolvePart1(List<string> input)
    {
        var rows = GetMap(input[0].Length, input);

        return FindLocationsToClear(rows).Count;
    }

    public int SolvePart2(List<string> input)
    {
        var removedRolls = 0;
        var allRollsRemoved = false;
        var rows = GetMap(input[0].Length, input);

        while (!allRollsRemoved)
        {
            var clearedLocations = FindLocationsToClear(rows);

            if (clearedLocations.Count == 0)
            {
                allRollsRemoved = true;
            }

            removedRolls += clearedLocations.Count;

            foreach (var location in clearedLocations)
            {
                var x = location[0];
                var y = location[1];

                var chars = rows[y].ToCharArray();
                chars[x] = '.';
                rows[y] = new string(chars);
            }
        }

        return removedRolls;
    }

    public List<string> GetMap(int width, List<string> input)
    {
        var rows = new List<string>();

        rows.Insert(0, new string('#', width + 2));

        foreach (var row in input)
        {
            rows.Add(row.PadLeft(row.Length + 1, '#').PadRight(row.Length + 2, '#'));
        }

        rows.Add(new string('#', input[0].Length + 2));
        return rows;
    }

    public List<int[]> FindLocationsToClear(List<string> rows)
    {
        var clearedLocations = new List<int[]>();

        for (var y = 1; y < rows.Count - 1; y++)
        {
            var row = rows[y];
            for (var x = 1; x < row.Length - 1; x++)
            {
                var adjacentRolls = 0;
                if (row[x] == '@')
                {
                    foreach (var direction in Directions)
                    {
                        var dx = direction[0];
                        var dy = direction[1];

                        var adjacentX = dx + x;
                        var adjacentY = dy + y;

                        if (rows[adjacentY][adjacentX] == '@')
                        {
                            adjacentRolls++;
                        }
                    }

                    if (adjacentRolls < 4)
                    {
                        clearedLocations.Add([x, y]);
                    }
                }
            }
        }

        return clearedLocations;
    }
}