using System;
using System.IO;
using System.Threading.Tasks;
using XPdfSharp_net48;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Demo_ExtractTextAsync();
            await Demo_ExtractImagesAsync();
        }

        private static async Task Demo_ExtractTextAsync()
        {
            var pdf2Text = new Pdf2Text
            {
                Raw = true,
                NoBreakPage = true
            };

            var text = await pdf2Text.ExtractTextAsync("samples/sample.pdf");

            Console.WriteLine(text);
        }

        private static async Task Demo_ExtractImagesAsync()
        {
            if (Directory.Exists("samples/images/"))
            {
                Directory.Delete("samples/images/", true);
            }

            var pdf2Png = new Pdf2Png
            {
                Dpi = 75
            };

            var result = await pdf2Png.GenerateImagesAsync("samples/sample.pdf", "samples/images/");

            Console.WriteLine($"Generated images success: { result == 0 } codeError: { result }");

            var files = Directory.GetFiles("samples/images/");
            Console.WriteLine($"Image Count: { files.Length }");
        }
    }
}