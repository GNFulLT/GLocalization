using GLocalization.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Conceretes
{
    /// <summary>
    /// Conrete type of IFileType includes the file types that GLocalization supports
    /// </summary>
    public class FileType : IFileType
    {   
        /// <summary>
        /// Extension of file type
        /// </summary>
        public string FileExtension { get => _extension; }

        private string _extension;
        private FileType(string extension)
        {
            _extension = extension;
        }
        
        /// <summary>
        /// Represents for JSON file
        /// </summary>
        public static FileType JSON = new FileType("json");

        internal static IFileType GetFileTypeByExtension(string extension)
        {
            switch (extension)
            {
                case "json": return JSON;
                default: return JSON;
            }
        }
    }
}
