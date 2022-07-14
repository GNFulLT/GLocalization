using GLocalization.Abstracts;
using GLocalization.Exceptions;
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

        /// <summary>
        /// Represents for YAML file
        /// </summary>
        public static FileType YAML = new FileType("yaml");

        internal static IFileType GetFileTypeByExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".json": return JSON;
                case ".yaml": return YAML;
                default: throw new NotSupportedFileTypeException();
            }
        }
    }
}
