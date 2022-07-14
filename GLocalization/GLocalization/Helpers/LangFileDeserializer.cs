using GLocalization.Abstracts;
using GLocalization.Helpers.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Helpers
{
    internal static class LangFileDeserializer
    {
        internal static Dictionary<string,string> Deserialize(string text,IFileType type)
        {
            SetDeserializeStrategy(type);
            return _deserializeStrategy.Deserialize(text);
        }

        private static ILangFileDeserializerStrategy _deserializeStrategy;

        private static void SetDeserializeStrategy(IFileType type)
        {
            switch (type.FileExtension)
            {
                case "json":
                    _deserializeStrategy = new JsonFileDeserializerStrategy();
                    return;
                case "yaml":
                    _deserializeStrategy = new YamlFileDeserializerStrategy();
                    return;
                default:
                    _deserializeStrategy = new JsonFileDeserializerStrategy();
                    return;
            }

        }
    }
}
