using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions
{
    /// <summary>
    /// If given file type is not supported by GLocalization
    /// </summary>
    public class NotSupportedFileTypeException : GLocalizationBaseException
    {
        /// <summary>
        /// If given file type is not supported by GLocalization
        /// </summary>
        public NotSupportedFileTypeException() : base("Given file type is not supported")
        { }
    }
}
