using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Find all classes implementing IDay
        var days = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IDay).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t => (IDay)Activator.CreateInstance(t)!)
            .ToDictionary(d => d.Day);

        Console.Write("Which day? \nPress any non numeric key to run all days. ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out var dayNumber))
        {
            Console.WriteLine("Running all days...\n");

            foreach (var d in days.Values.OrderBy(d => d.Day))
            {
                Console.WriteLine($"Running Day {d.Day}...\n");
                d.Run();
                Console.WriteLine();
            }
            return;
        }

        if (days.TryGetValue(dayNumber, out var day))
        {
            Console.WriteLine($"Running Day {dayNumber}...\n");
            day.Run();
        }
        else
        {
            Console.WriteLine($"Day {dayNumber} not found.");
        }
    }
}
