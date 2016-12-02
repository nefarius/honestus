namespace honestus
{
    public class Patterns
    {
        public static string AssemblyVersion => @"^ *\[assembly[\: ]*AssemblyVersion.*\]";

        public static string AssemblyFileVersion => @"^ *\[assembly[\: ]*AssemblyFileVersion.*\]";

        public static string ResourceFileVersion => @"^ *FILEVERSION *\d*,\d*,\d*,\d*";

        public static string ResourceProductVersion => @"^ *PRODUCTVERSION *\d*,\d*,\d*,\d*";

        public static string ResourceStringFileVersion => "^[ \\t]*VALUE *\"FileVersion\" *, *\"\\d*\\.\\d*\\.\\d*\\.\\d*\"";

        public static string ResourceStringProductVersion => "^[ \\t]*VALUE *\"ProductVersion\" *, *\"\\d*\\.\\d*\\.\\d*\\.\\d*\"";
    }
}