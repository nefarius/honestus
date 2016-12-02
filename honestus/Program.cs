using System;
using System.IO;
using System.Text.RegularExpressions;
using CommandLine;

namespace honestus
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            var isValid = Parser.Default.ParseArgumentsStrict(args, options);

            if (!isValid) return;

            options.UseVersionFromFile();

            if (options.OverwriteAssemblyVersion)
            {
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.AssemblyVersion,
                        options.AssemblyVersionString, RegexOptions.Multiline));
            }

            if (options.OverwriteAssemblyFileVersion)
            {
                File.WriteAllText(options.TargetFile,
                Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.AssemblyFileVersion,
                    options.AssemblyFileVersionString, RegexOptions.Multiline));
            }
        }
    }
}
