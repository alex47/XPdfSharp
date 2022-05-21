using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace XPdfSharp_net48
{
    public class Pdf2Png
    {
        public string Suffix { get; set; } = "page";
        
        public int FirstPage { get; set; }
        
        public int LastPage { get; set; }
        
        public int Dpi { get; set; } = 150;
        
        public bool Monochrome { get; set; }
        
        public bool GrayScale { get; set; }
        
        public bool IncludeAlpha { get; set; }
        
        public int Rotation { get; set; } = 0;
        
        public bool EnableFreeType { get; set; }
        
        public bool FontAntiAliasing { get; set; }
        
        public bool VectorAntiAliasing { get; set; }
        
        public async Task<int> GenerateImagesAsync(string pdfFilePath, string outputDirectory)
        {
            if (File.Exists(pdfFilePath) == false || Directory.CreateDirectory(outputDirectory).Exists == false)
            {
                return -1;
            }
            
            if (outputDirectory.Last() != Path.DirectorySeparatorChar)
            {
                outputDirectory = string.Concat(outputDirectory, Path.DirectorySeparatorChar);
            }

            var arguments = ParseParameters();

            arguments.Add(LibUtils.QuoteString(pdfFilePath));
            arguments.Add(LibUtils.QuoteString($"{ outputDirectory }{ Suffix }"));

            var programName = LibUtils.XPDFTools_pdftopngPath;
            var joinedArguments = LibUtils.JoinParameters(arguments);

            return await CustomProcess.RunProcessAsync(programName, joinedArguments);
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

            if (Monochrome)
            {
                arguments.Add("-mono");
            }

            if (GrayScale)
            {
                arguments.Add("-gray");
            }

            if (IncludeAlpha)
            {
                arguments.Add("-alpha");
            }

            if (EnableFreeType)
            {
                arguments.Add("-freetype yes");
            }

            if (FontAntiAliasing)
            {
                arguments.Add("-aa yes");
            }

            if (VectorAntiAliasing)
            {
                arguments.Add("-aaVector yes");
            }

            arguments.Add($"-r { Dpi }");
            arguments.Add($"-rot { Rotation }");

            return arguments;
        }
    }
}