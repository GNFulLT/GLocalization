using GLocalization.Abstracts;
using GLocalization.Exceptions.CannotConvert;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Helpers.Strategies
{
    internal class JsonFileDeserializerStrategy : ILangFileDeserializerStrategy
    {
        public Dictionary<string, string> Deserialize(string json)
        {
            Dictionary<string, string>? dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            if (dict == null)
                throw new CannotConvertJSONException();

            return dict;
        }
    }
}
