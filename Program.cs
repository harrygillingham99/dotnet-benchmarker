using System;
using System.ComponentModel;
using System.Linq;

namespace Benchmarker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter next command: (type help to see all commands)");
                ProcessCommand(Console.ReadLine());
            }
        }

        private static void ProcessCommand(string input)
        {
            var cleanupConsole = true;

            bool InputMatchesCommand(Commands command)
            {
                return input.Equals(GetEnumDescription(command),
                    StringComparison.InvariantCultureIgnoreCase);
            }

            switch (input)
            {
                case var _ when InputMatchesCommand(Commands.AllTests):
                    new BenchmarkRunner.BenchmarkRunner().RunBenchmarks();
                    break;
                case var _ when InputMatchesCommand(Commands.Help):
                    PrintAllCommands();
                    cleanupConsole = false;
                    break;
                case var _ when InputMatchesCommand(Commands.Quit):
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Command not found, type help to see all commands.");
                    cleanupConsole = false;
                    break;
            }

            if (cleanupConsole) CleanupConsole();
        }

        private static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[]) fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
        }

        private static void CleanupConsole()
        {
            Console.WriteLine("\n \nDone! Press any key...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintAllCommands()
        {
            var descriptions = Enum.GetValues(typeof(Commands)).Cast<Commands>()
                .Where(command => command != Commands.Help)
                .Select(command => GetEnumDescription(command));
            Console.WriteLine("The following commands are not case sensitive: ");
            descriptions.ToList().ForEach(Console.WriteLine);
        }

        internal enum Commands
        {
            [Description("Help")] Help = 0,
            [Description("Run All Tests")] AllTests = 1,
            [Description("List All Tests")] ListTests = 2,
            [Description("Run Specific Test")] SpecificTest = 3,
            [Description("Quit")] Quit = 4
        }
    }
}