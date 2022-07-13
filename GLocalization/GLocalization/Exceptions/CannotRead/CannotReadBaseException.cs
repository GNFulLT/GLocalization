using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotReaded
{
    /// <summary>
    /// If file cannot be read because of unknown reasons 
    /// </summary>
    public class CannotReadBaseException : GLocalizationBaseException
    {
        /// <summary>
        /// If file cannot be read because of unknown reasons 
        /// </summary>
        public CannotReadBaseException(string s ) : base(s) { }
    }
}
