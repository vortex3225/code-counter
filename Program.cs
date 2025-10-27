using Code_Counter;

namespace CodeCounter
{
    internal class Program
    {

        private static void MainProgramFunction(string[] args)
        {
            string? file_path = null;
            string? file_extensions = null;
            List<string> excluded_directories = new List<string>();
            bool output_results_to_file = false;

            if (args.Length >= 4)
            {
                file_path = args[0];
                file_extensions = args[1];
                excluded_directories = args[3].Split("+").ToList();
                if (!bool.TryParse(args[2], out output_results_to_file))
                {
                    Console.WriteLine("Could not resolve boolean value, defaulting to false.");
                    output_results_to_file = false;
                }
            }
            else
            {
                Console.Write("Project directory path: ");
                file_path = Console.ReadLine();
                Console.Write("File extensions to check (Example: .cpp+.py+.cs+.c | * for most common code file extensions):");
                file_extensions = Console.ReadLine();
                Console.Write("Write results to output file (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out output_results_to_file))
                {
                    Console.WriteLine("Could not resolve boolean value, defaulting to false.");
                    output_results_to_file = false;
                }
                Console.Write(@"Excluded directories (Example: C:\Downloads\Project 1\.git), press enter to continue: ");
                string? res = Console.ReadLine();
                while (!string.IsNullOrEmpty(res))
                {
                    excluded_directories.Add(res);
                    Console.WriteLine("Enter a new exclusion or press enter to continue: ");
                    res = Console.ReadLine();
                }

            }

            int total_lines = CounterManager.CountLinesOfCode(file_path, file_extensions, output_results_to_file, excluded_directories);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine($"TOTAL PROJECT LINES: {total_lines}");
            Console.ReadLine();
        }

        private static void Main(string[] args)
        {
            string? response = null;
            do
            {
                MainProgramFunction(args);
                Console.Write($"\n\n\n\nWould you like to count a new project (y/n)?");
                response = Console.ReadLine();
            } while (!string.IsNullOrEmpty(response) && response.ToLower() != "n");

        }
    }
}