using System.Collections.Generic;

namespace honestus
{
    public class Patterns
    {
        public static KeyValuePair<string, string> AssemblyVersion
            =>
                new KeyValuePair<string, string>(@"^ *\[assembly[\: ]*AssemblyVersion.*\]",
                    "[assembly: AssemblyVersion(\"{0}\")]");

        public static KeyValuePair<string, string> AssemblyFileVersion =>
            new KeyValuePair<string, string>(@"^ *\[assembly[\: ]*AssemblyFileVersion.*\]",
                "[assembly: AssemblyFileVersion(\"{0}\")]");

        public static KeyValuePair<string, string> ResourceFileVersion =>
            new KeyValuePair<string, string>(@"FILEVERSION *\d*,\d*,\d*,\d*", "FILEVERSION ");

        public static KeyValuePair<string, string> ResourceProductVersion =>
            new KeyValuePair<string, string>(@"PRODUCTVERSION *\d*,\d*,\d*,\d*", "PRODUCTVERSION {0}");

        public static KeyValuePair<string, string> ResourceStringFileVersion
            => new KeyValuePair<string, string>("^[ \\t]*VALUE *\"FileVersion\" *, *\"\\d*\\.\\d*\\.\\d*\\.\\d*\"",
                "VALUE \"FileVersion\", \"{0}\"");

        public static KeyValuePair<string, string> ResourceStringProductVersion
            => new KeyValuePair<string, string>("^[ \\t]*VALUE *\"ProductVersion\" *, *\"\\d*\\.\\d*\\.\\d*\\.\\d*\"",
                "VALUE \"ProductVersion\", \"{0}\"");
    }
}
