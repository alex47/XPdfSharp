using System.Diagnostics;
using System.Threading.Tasks;

namespace XPdfSharp_net48
{
    internal static class CustomProcess
    {
        public static Task<int> RunProcessAsync(string filePath, string arguments)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            var process = CreateNewProcess(filePath, arguments);

            process.Exited += (sender, args) =>
            {
                taskCompletionSource.SetResult(process.ExitCode);
                process.Dispose();
            };

            process.Start();
            return taskCompletionSource.Task;
        }        
        
        private static Process CreateNewProcess(string fileName, string arguments)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };               
        }
    }
}