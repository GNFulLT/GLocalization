using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Abstracts
{
    internal interface ILangFileDeserializerStrategy
    {
        public Dictionary<string, string> Deserialize(string text);
    }
}
