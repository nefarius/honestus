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
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.AssemblyVersion.Key,
                        string.Format(Patterns.AssemblyVersion.Value, options.Version), RegexOptions.Multiline));
            }

            if (options.OverwriteAssemblyFileVersion)
            {
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.AssemblyFileVersion.Key,
                        string.Format(Patterns.AssemblyFileVersion.Value, options.Version), RegexOptions.Multiline));
            }

            if (options.OverwriteResourceFileVersion)
            {
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.ResourceFileVersion.Key,
                        string.Format(Patterns.ResourceFileVersion.Value, options.Version.ToString().Replace('.', ',')),
                        RegexOptions.Multiline));
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.ResourceStringFileVersion.Key,
                        string.Format(Patterns.ResourceStringFileVersion.Value, options.Version), RegexOptions.Multiline));
            }

            if (options.OverwriteResourceProductVersion)
            {
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.ResourceProductVersion.Key,
                        string.Format(Patterns.ResourceProductVersion.Value, options.Version.ToString().Replace('.', ',')),
                        RegexOptions.Multiline));
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.ResourceStringProductVersion.Key,
                        string.Format(Patterns.ResourceStringProductVersion.Value, options.Version), RegexOptions.Multiline));
            }

            if (options.OverwriteVcxprojInfTimeStamp)
            {
                File.WriteAllText(options.TargetFile,
                    Regex.Replace(File.ReadAllText(options.TargetFile), Patterns.VcxprojInfTimeStamp.Key,
                        string.Format(Patterns.VcxprojInfTimeStamp.Value, options.Version), RegexOptions.Multiline));
            }
        }
    }
}