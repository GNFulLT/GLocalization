using GLocalization.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Conceretes
{
    public class FileType : IFileType
    {        
        public string FileExtension { get => _extension; }

        private string _extension;
        private FileType(string extension)
        {
            _extension = extension;
        }

        public static FileType JSON = new FileType("json");

        public static IFileType GetFileTypeByExtension(string extension)
        {
            switch (extension)
            {
                case "json": return JSON;
                default: return JSON;
            }
        }
    }
}
