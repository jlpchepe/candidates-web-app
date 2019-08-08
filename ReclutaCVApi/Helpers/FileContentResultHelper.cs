using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Helpers
{
    public class FileContentResultHelper
    {
        public static FileContentResult CreateFileContentResult(
            byte[] content,
            string fileName
        )
        {
            var contentType = "application/octet-stream";
            var file = new FileContentResult(content, contentType)
            {
                FileDownloadName = fileName,
            };

            return file;
        }
    }
}
