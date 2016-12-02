using System;
using System.IO;
using CommandLine;

namespace honestus
{
    public class Options
    {
        [Option("version")]
        public Version Version { get; set; }

        [Option("version-from-file")]
        public string TargetVersionFile { get; set; }

        [Option("target-file")]
        public string TargetFile { get; set; }

        [Option("assembly.version")]
        public bool OverwriteAssemblyVersion { get; set; }

        [Option("assembly.file-version")]
        public bool OverwriteAssemblyFileVersion { get; set; }

        [Option("resource.file-version")]
        public bool OverwriteResourceFileVersion { get; set; }

        [Option("resource.product-version")]
        public bool OverwriteResourceProductVersion { get; set; }

        [Option("vcxproj.inf-time-stamp")]
        public bool OverwriteVcxprojInfTimeStamp { get; set; }

        public void UseVersionFromFile()
        {
            if (!File.Exists(TargetVersionFile)) return;

            Version = Version.Parse(File.ReadAllText(TargetVersionFile).Trim(' ', '\n', '\r'));
        }
    }
}