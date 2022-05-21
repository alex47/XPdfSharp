using System;
using System.Collections.Generic;
using System.IO;

namespace XPdfSharp_net48
{
    public static class LibUtils
    {
        private const string DefaultExt = "tmp";
        private const string Quoted = "\"";
        private const string ArgumentEnd = " ";
        private const string WindowsExtension = ".exe";
        
        public static string RandomFileName(string ext = DefaultExt) => $"{Guid.NewGuid()}.{ext}";
        public static string RandomTempFile(string ext = DefaultExt) => $"{Path.GetTempPath()}{RandomFileName(ext)}";
        public static string QuotedStr(string str) => string.Concat(Quoted, str, Quoted);
        public static string ParseParameters(IEnumerable<string> arguments) => string.Join(ArgumentEnd, arguments);
        public static string WorkDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public static string GetProgramName(string programBase)
        {
            return string.Concat(WorkDirectory, programBase, WindowsExtension);
        }
        
    }
}