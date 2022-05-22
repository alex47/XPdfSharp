# XPdfSharp_net48
Wrapper of XPdf Tools for C#

This project targets .NET Framework 4.8

## How Install ##
Available at nuget [XPDFSharp](https://www.nuget.org/packages/XPDFSharp_net48/)

## Features: ##
 * Extraction of PDF text
 * Print PDF to PNG files

## Usage ##

```
var pdf2Text = new XPdfSharp_net48.Pdf2Text
{
    Simple = true
};

string extractedText = await pdf2Text.ExtractTextAsync(pdfFilePath);
Console.WriteLine(extractedText);
```


Also change this field to Copy if newer for the exe files.

![image](https://user-images.githubusercontent.com/10761683/169700781-47ca9d04-a519-4381-9fdb-7b339a7178d5.png)
