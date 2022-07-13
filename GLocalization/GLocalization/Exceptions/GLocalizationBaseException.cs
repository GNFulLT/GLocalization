using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions
{
    public class GLocalizationBaseException : Exception
    {
        public GLocalizationBaseException()
        { }
        public GLocalizationBaseException(string desc) : base(desc)
        { }
    }
}
