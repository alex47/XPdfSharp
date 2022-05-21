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
    }
}