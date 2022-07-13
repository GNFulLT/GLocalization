using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotConvert
{
    public class CannotConvertJSONException : CannotConvertBaseException
    {
        public CannotConvertJSONException() : base("JSON")
        { }
    }
}
