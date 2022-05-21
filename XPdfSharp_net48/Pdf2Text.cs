using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace XPdfSharp_net48
{
    public class Pdf2Text
    {
        public int FirstPage { get; set; }
        
        public int LastPage { get; set; }
        
        public string Encode { get; set; } = "UTF-8";
        
        public bool Layout { get; set; }
        
        public bool Table { get; set; }
        
        public bool Raw { get; set; }
        
        public bool NoBreakPage { get; set; }
        
        public bool NoDiagonal { get; set; }
        
        public bool Clip { get; set; }
        
        public bool Simple { get; set; }
        
        public async Task<string> ExtractTextAsync(string pdfFilePath)
        {
            var tempFilePath = Path.GetTempFileName();
            var arguments = ParseParameters();

            arguments.Add(LibUtils.QuoteString(pdfFilePath));
            arguments.Add(LibUtils.QuoteString(tempFilePath));

            var programName = LibUtils.XPDFTools_pdftotextPath;
            var joinedArguments = LibUtils.JoinParameters(arguments);

            await CustomProcess.RunProcessAsync(programName, joinedArguments);

            if (File.Exists(tempFilePath) == false)
            {
                return string.Empty;
            }
            
            var text = File.ReadAllText(tempFilePath);
            File.Delete(tempFilePath);
            
            return text;
        }

        private List<string> ParseParameters()
        {
            var arguments = new List<string>();

            if (0 < FirstPage)
            {
                arguments.Add($"-f { FirstPage }");
            }

            if (0 < LastPage)
            {
                arguments.Add($"-l { LastPage }");
            }

            if (Layout)
            {
                arguments.Add("-layout");
            }

            if (Table)
            {
                arguments.Add("-table");
            }

            if (Raw)
            {
                arguments.Add("-raw");
            }

            if (Clip)
            {
                arguments.Add("-clip");
            }

            if (Simple)
            {
                arguments.Add("-simple");
            }

            if (NoDiagonal)
            {
                arguments.Add("-nodiag");
            }
            
            if (NoBreakPage)
            {
                arguments.Add("-nopgbrk");
            }

            arguments.Add($"-enc { Encode }");

            return arguments;
        }
    }
}