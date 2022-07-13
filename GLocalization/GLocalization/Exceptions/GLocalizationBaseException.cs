using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions
{
    /// <summary>
    /// Base Exception for GLocalization
    /// </summary>
    public class GLocalizationBaseException : Exception
    {
        /// <summary>
        /// Base Exception for GLocalization
        /// </summary>
        public GLocalizationBaseException(string desc) : base(desc)
        { }
    }
}
