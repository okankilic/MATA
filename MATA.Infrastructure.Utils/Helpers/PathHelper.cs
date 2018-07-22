using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Infrastructure.Utils.Helpers
{
    public static class PathHelper
    {
        private static string AttachmentsDirectory
        {
            get
            {
                var attachmentsDirectory = ConfigurationManager.AppSettings.Get("AttachmentsDirectory");

                if (!Directory.Exists(attachmentsDirectory))
                {
                    Directory.CreateDirectory(attachmentsDirectory);
                }

                return attachmentsDirectory;
            }
        }

        public static string GetAttachmentFilePath(string filePath)
        {
            return Path.Combine(AttachmentsDirectory, filePath);
        }
    }
}
