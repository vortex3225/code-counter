using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Counter
{
    public static class FileExtensions
    {
        public static Dictionary<string, string> Extensions = new Dictionary<string, string>
        {
            // Popular programming languages
            {".c", "C Source File"},
            {".cpp", "C++ Source File"},
            {".h", "C/C++ Header File"},
            {".hpp", "C++ Header File"},
            {".cs", "C# Source File"},
            {".java", "Java Source File"},
            {".py", "Python Script"},
            {".js", "JavaScript File"},
            {".ts", "TypeScript File"},
            {".jsx", "React JSX File"},
            {".tsx", "React TSX File"},
            {".rb", "Ruby Script"},
            {".php", "PHP File"},
            {".go", "Go Source File"},
            {".rs", "Rust Source File"},
            {".swift", "Swift Source File"},
            {".kt", "Kotlin Source File"},
            {".m", "Objective-C Source File"},
            {".mm", "Objective-C++ Source File"},
            {".scala", "Scala Source File"},
            {".dart", "Dart Source File"},
        
            // Scripting / Shell
            {".sh", "Shell Script"},
            {".bat", "Batch File"},
            {".ps1", "PowerShell Script"},
            {".pl", "Perl Script"},
            {".lua", "Lua Script"},
            {".r", "R Script"},
            {".groovy", "Groovy Script"},
        
            // Web / Markup
            {".html", "HTML File"},
            {".htm", "HTML File"},
            {".css", "CSS File"},
            {".scss", "Sass File"},
            {".less", "Less File"},
            {".xml", "XML File"},
            {".xaml", "XAML File"},
            {".json", "JSON File"},
            {".yaml", "YAML File"},
            {".yml", "YAML File"},
            {".md", "Markdown File"},
            {".txt", "Text File"},
        
            // Config / Project
            {".ini", "INI File"},
            {".cfg", "Config File"},
            {".toml", "TOML File"},
            {".env", "Environment File"},
            {".dockerfile", "Dockerfile"},
            {".makefile", "Makefile"},
            {".gradle", "Gradle Build File"},
            {".csproj", "C# Project File"},
            {".sln", "Visual Studio Solution File"},
            {".pom", "Maven POM File"},
        
            // Data / SQL
            {".sql", "SQL File"},
            {".sqlite", "SQLite Database File"},
            {".db", "Database File"},
        
            // Misc / Niche
            {".v", "Verilog Source File"},
            {".sv", "SystemVerilog Source File"},
            {".vhdl", "VHDL Source File"},
            {".asm", "Assembly Source File"},
            {".s", "Assembly Source File"},
            {".f", "Fortran Source File"},
            {".f90", "Fortran 90 Source File"},
            {".erl", "Erlang Source File"},
            {".ex", "Elixir Source File"},
            {".exs", "Elixir Script"},
        };
    }
}
