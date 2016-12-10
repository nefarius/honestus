﻿using System;
using System.IO;
using CommandLine;
using CommandLine.Text;

namespace honestus
{
    public class Options
    {
        [Option("version", MutuallyExclusiveSet = "version",
            HelpText = "The version information to set in the target file (e.g. \"1.2.0.0\").")]
        public Version Version { get; set; }

        [Option("version-from-file", MutuallyExclusiveSet = "version-file",
            HelpText = "A text file containing one line that gets parsed as the target version.")]
        public string TargetVersionFile { get; set; }

        [Option("target-file",
            HelpText = "The target file to get parsed and modified.")]
        public string TargetFile { get; set; }

        [Option("assembly.version",
            HelpText = "Update 'AssemblyVersion' attribute in the specified assembly source file.")]
        public bool OverwriteAssemblyVersion { get; set; }

        [Option("assembly.file-version",
            HelpText = "Update 'AssemblyFileVersion' attribute in the specified assembly source file.")]
        public bool OverwriteAssemblyFileVersion { get; set; }

        [Option("resource.file-version",
            HelpText = "Update 'FILEVERSION' and 'FileVersion' values in the specified resource file.")]
        public bool OverwriteResourceFileVersion { get; set; }

        [Option("resource.product-version",
            HelpText = "Update 'PRODUCTVERSION' and 'ProductVersion' values in the specified resource file.")]
        public bool OverwriteResourceProductVersion { get; set; }

        [Option("vcxproj.inf-time-stamp",
            HelpText = "Update '<TimeStamp>' value in the specified Visual Studio project file.")]
        public bool OverwriteVcxprojInfTimeStamp { get; set; }

        public void UseVersionFromFile()
        {
            if (!File.Exists(TargetVersionFile)) return;

            Version = Version.Parse(File.ReadAllText(TargetVersionFile).Trim(' ', '\n', '\r'));
        }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}