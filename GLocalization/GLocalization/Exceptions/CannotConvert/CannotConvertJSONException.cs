using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotConvert
{
    /// <summary>
    /// If json file cannot converted to C# object
    /// </summary>
    public class CannotConvertJSONException : CannotConvertBaseException
    {
        /// <summary>
        /// If json file cannot converted to C# object
        /// </summary>
        public CannotConvertJSONException() : base("JSON")
        { }
    }
}
