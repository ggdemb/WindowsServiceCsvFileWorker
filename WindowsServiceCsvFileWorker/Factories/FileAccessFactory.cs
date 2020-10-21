using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsServiceCsvFileWorker.Factories
{
    public static class FileAccessFactory
    {
        //https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application/
        public static Func<FileStream> GetReadOnlyFileStream(string filePath)
        {
            return () => File.OpenRead(filePath);
        }
    }
}
