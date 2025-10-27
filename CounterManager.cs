using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Counter
{
    public static class CounterManager
    {
        private static string output_file_contents = string.Empty;

        private static void AddOutputContent(string str)
        {
            output_file_contents += (str + "\n");
            Console.WriteLine("Added counted lines to output file.");
        }

        private static bool IsDirectoryExcluded(string f_path, List<string> excluded)
        {

            foreach (string f in excluded)
            {
                if (f_path.Contains(f))
                    return true;
            }

            return false;
        }

        public static int CountLinesOfCode(string ?file_path, string ?extensions, bool output_to_file, List<string> excluded_directories)
        {

            if (string.IsNullOrEmpty(file_path) || string.IsNullOrEmpty(extensions)) return 0;

            int counted = 0;

            int file_with_most_lines_count = 0;
            string file_path_with_most_lines = string.Empty;
            int file_with_least_lines_count = int.MaxValue;
            string file_path_with_least_lines = string.Empty;

            bool is_dir_or_file = Directory.Exists(file_path);

            void Handle(string file_path)
            {
                int lines = File.ReadAllLines(file_path).Length;
                counted += lines;

                if (lines > file_with_most_lines_count)
                {
                    file_with_most_lines_count = lines;
                    file_path_with_most_lines = file_path;
                }
                else if (lines < file_with_least_lines_count)
                {
                    file_with_least_lines_count = lines;
                    file_path_with_least_lines = file_path;
                }

                if (output_to_file) AddOutputContent($"{file_path}: {lines} LINES");
            }

            if (!is_dir_or_file)
            {
                try
                {
                    counted = File.ReadLines(file_path).ToList().Count;
                    AddOutputContent($"{file_path}: {counted} LINES");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    return 0;
                }
            }
            else
            {

                try
                {
                    string[] all_files = Directory.GetFiles(file_path, "*.*", SearchOption.AllDirectories);
                    foreach (string file_p in all_files)
                    {
                        Console.WriteLine($"Checking {file_p}");
                        if (extensions != "*")
                        {
                            if (IsDirectoryExcluded(file_p, excluded_directories))
                            {
                                Console.WriteLine($"File is in an excluded directory, skipped.");
                                continue;
                            }

                            string file_extension = Path.GetExtension(file_p);
                            if (extensions.Contains(file_extension))
                            {
                                Handle(file_p);
                            }
                        }
                        else Handle(file_p);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    return 0;
                }

            }

            if (output_to_file)
            {
                output_file_contents += $"\n\n\n\nTOTAL LINES: {counted}";
                output_file_contents += $"\n\nFILE WITH THE MOST LINES: {file_path_with_most_lines} WITH {file_with_most_lines_count}";
                output_file_contents += $"\n\nFILE WITH THE LEAST LINES: {file_path_with_least_lines} WITH {file_with_least_lines_count}";
                output_file_contents += $"\n\n\nCounted at: {DateTime.Now.ToString("dd/MM/yyyyy @ HH:mm")}";

                string output_path = Path.Combine(AppContext.BaseDirectory, "output.log");

                int tried = 1;
                while (File.Exists(output_path))
                {
                    output_path = Path.Combine(AppContext.BaseDirectory, $"output{tried}.log");
                }

                File.WriteAllText(output_path, output_file_contents);
                Console.WriteLine($"Wrote results to {output_path}");
                output_file_contents = string.Empty;
                file_path_with_most_lines = string.Empty;
                file_with_most_lines_count = 0;
            }
            else Console.WriteLine(output_file_contents);

            return counted;
        }

    }
}