using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotFind
{
    /// <summary>
    /// If file couldn't find 
    /// </summary>
    public class CannotFindBaseException : GLocalizationBaseException
    {
        /// <summary>
        /// If file couldn't find 
        /// </summary>
        public CannotFindBaseException(string lookedAt) : base($"Cannot any file with this path : {lookedAt}")
        {

        }
    }
}
