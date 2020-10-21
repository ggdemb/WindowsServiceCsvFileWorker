using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WindowsServiceCsvFileWorker.Model;

namespace WindowsServiceCsvFileWorker.Services
{
    public class FileProcessService : IFileProcessService
    {
        private readonly ILogger _logger;

        public FileProcessService(ILogger<FileProcessService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ProcesFileIfExsistsAsync(CancellationToken stoppingToken)
        {
            var filePath = @"C:\Users\dembo\source\repos\My projects\WindowsServiceCsvFileWorker\WindowsServiceCsvFileWorker\SampleData\airline-safety.csv";//this should be injected from options;

            var result = await Disposable.UsingAsync(
                () => File.OpenRead(filePath),
                async stream =>
                {
                    return await Disposable.UsingAsync(
                    () => new StreamReader(stream),
                    GetAllLines(stoppingToken));
                });

            var deserializedObjects = result.Select(AirlineSafety.Create).ToList();
        }

        //https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application/
        private static Func<StreamReader, Task<List<string>>> GetAllLines(CancellationToken stoppingToken)
        {
            return async streamReader =>
            {
                List<string> lines = new List<string>();
                string line;

                if (await streamReader.ReadLineAsync() is object) //skip line, how can I do this in more functional way?
                {
                    while (!stoppingToken.IsCancellationRequested && (line = await streamReader.ReadLineAsync()) is object)
                    {
                        lines.Add(line);
                    }
                }
                return lines;
            };
        }
    }
}
