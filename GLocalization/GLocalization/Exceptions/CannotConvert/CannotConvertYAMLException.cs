using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotConvert
{
    /// <summary>
    /// If yaml file cannot converted to C# object
    /// </summary>
    public class CannotConvertYAMLException : CannotConvertBaseException
    {
        /// <summary>
        /// If yaml file cannot converted to C# object
        /// </summary>
        public CannotConvertYAMLException() : base("YAML")
        { }
    }
}
