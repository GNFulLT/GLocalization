using GLocalization.Abstracts;
using GLocalization.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace GLocalization.Helpers.Strategies
{
    internal class YamlFileDeserializerStrategy : ILangFileDeserializerStrategy
    {
        public Dictionary<string, string> Deserialize(string text)
        {
            var deserializer = new DeserializerBuilder().Build();
            Dictionary<string,string> dict = deserializer.Deserialize<Dictionary<string,string>>(text);
            if (dict == null)
                throw new GLocalizationBaseException("Cannot convert yaml file");
            return dict;
        }
    }
}
