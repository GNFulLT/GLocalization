using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Abstracts
{
    /// <summary>
    /// Represents for file type 
    /// </summary>
    public interface IFileType
    {
        /// <summary>
        /// Extension of file type
        /// </summary>
        string FileExtension { get; }
    }
}
