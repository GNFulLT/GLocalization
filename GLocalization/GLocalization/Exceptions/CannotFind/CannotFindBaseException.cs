using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Exceptions.CannotFind
{
    public class CannotFindBaseException : GLocalizationBaseException
    {
        public CannotFindBaseException(string lookedAt) : base($"Cannot any file with this path : {lookedAt}")
        {

        }
    }
}
