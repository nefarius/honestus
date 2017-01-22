using System;
using System.Text;
using CommandLine;

namespace honestus
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            var isValid = Parser.Default.ParseArgumentsStrict(args, options);

            if (!isValid || args.Length <= 1)
            {
                Console.WriteLine(options.GetUsage());
                return;
            }

            options.UseVersionFromFile();

            if (options.OverwriteAssemblyVersion)
            {
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.AssemblyVersion.Key,
                    string.Format(Patterns.AssemblyVersion.Value, options.Version));
            }

            if (options.OverwriteAssemblyFileVersion)
            {
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.AssemblyFileVersion.Key,
                    string.Format(Patterns.AssemblyFileVersion.Value, options.Version));
            }

            if (options.OverwriteResourceFileVersion)
            {
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.ResourceFileVersion.Key,
                    string.Format(Patterns.ResourceFileVersion.Value, options.Version.ToString().Replace('.', ',')),
                    Encoding.Default);
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.ResourceStringFileVersion.Key,
                    string.Format(Patterns.ResourceStringFileVersion.Value, options.Version), Encoding.Default);
            }

            if (options.OverwriteResourceProductVersion)
            {
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.ResourceProductVersion.Key,
                    string.Format(Patterns.ResourceProductVersion.Value, options.Version.ToString().Replace('.', ',')),
                    Encoding.Default);
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.ResourceStringProductVersion.Key,
                    string.Format(Patterns.ResourceStringProductVersion.Value, options.Version), Encoding.Default);
            }

            if (options.OverwriteVcxprojInfTimeStamp)
            {
                TextFileHelper.RegexReplace(options.TargetFile, Patterns.VcxprojInfTimeStamp.Key,
                    string.Format(Patterns.VcxprojInfTimeStamp.Value, options.Version));
            }
        }
    }
}
