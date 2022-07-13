using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotConvert
{
    public class CannotConvertBaseException : GLocalizationBaseException
    {
        public CannotConvertBaseException(string fileName) : base($"{fileName} file type cannot converted to dictionary maybe given file type is wrong")
        { }
    }
}
