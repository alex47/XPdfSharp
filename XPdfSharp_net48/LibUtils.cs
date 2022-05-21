using System;
using System.Collections.Generic;

namespace XPdfSharp_net48
{
    internal static class LibUtils
    {
        private const string Quoted = "\"";
        private const string ArgumentEnd = " ";
        
        public static string QuoteString(string str) => string.Concat(Quoted, str, Quoted);
        
        public static string JoinParameters(IEnumerable<string> arguments) => string.Join(ArgumentEnd, arguments);
        
        public static string ApplicationDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public static string XPDFTools_pdftotextPath => $@"{ XPDFToolsDirectoryPath }\pdftotext.exe";
        
        public static string XPDFTools_pdftopngPath => $@"{ XPDFToolsDirectoryPath }\pdftotext.exe";
        
        private static string XPDFToolsDirectoryPath => $@"{ AppDomain.CurrentDomain.BaseDirectory }\xpdftools_lib\";
    }
}