using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotConvert
{
    /// <summary>
    /// If a file cannot converted C# object base exception
    /// </summary>
    public class CannotConvertBaseException : GLocalizationBaseException
    {   
        /// <summary>
        /// If a file cannot converted C# object base exception
        /// </summary>
        public CannotConvertBaseException(string fileName) : base($"{fileName} file type cannot converted to dictionary maybe given file type is wrong")
        { }
    }
}
