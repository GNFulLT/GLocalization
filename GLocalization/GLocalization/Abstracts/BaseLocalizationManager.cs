using GLocalization.Attributes;
using GLocalization.Conceretes;
using GLocalization.Exceptions;
using GLocalization.Exceptions.CannotFind;
using GLocalization.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GLocalization.Abstracts
{
    /// <summary>
    /// Base class for localization manager classes
    /// </summary>
    public abstract class BaseLocalizationManager
    {
        
        private IGlobalSettings _settings;
        private readonly string LOCALIZATION_PREFIX;

        private Dictionary<string, string>? _localization;
        public BaseLocalizationManager(string prefix, IGlobalSettings settings)
        {
            LOCALIZATION_PREFIX = prefix;
            _settings = settings;
        }
        
        /// <summary>
        /// Loads localization data by given settings
        /// </summary>
        public void LoadLocalizationData()
        {
                ReadOnlySpan<char> path = @$"./{_settings.LocalizationFolderPath}/${LOCALIZATION_PREFIX}.{_settings.LocalizationEndPrefix}.{_settings.FileType.FileExtension}";
            //Check there is a file can be readed
            if (!File.Exists(path.ToString()))
                throw new CannotFindBaseException(path.ToString());
                if (DefaultLocalizationManager.DefaultLocalization is null)
                    throw new Exception("Default localization is not provided");

                var fileAsString = File.ReadAllText(path.ToString());

                Dictionary<string,string> deserializedLang = LangFileDeserializer.Deserialize(fileAsString, _settings.FileType);

                //Check if there is a key that deserializedlang doesn't have but default localization has and if there is, add it to deserializedLang
                foreach(var pair in DefaultLocalizationManager.DefaultLocalization)
                { 
                    if(!deserializedLang.ContainsKey(pair.Key))
                    {
                        deserializedLang.Add(pair.Key, pair.Value);
                    }
                }

                _localization = deserializedLang;
        }
        public void SetLocalization<T>(T viewModel)
        {
            if (_localization is null)
                throw new Exception("Localization is not provided");
            var type = typeof(T);

            foreach (var item in type.GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    object[] attrs = item.GetCustomAttributes(true);

                    foreach (var attr in attrs)
                    {
                        if (attr.GetType() == typeof(LocalizablePropertyAttribute))
                        {
                            var localizationAttr = attr as LocalizablePropertyAttribute;
                            string propName = localizationAttr!.PropertyName;
                            string keyName = localizationAttr.KeyName;
                            if(_localization.ContainsKey(keyName))
                            {
                                type.GetProperty(propName).SetValue(viewModel, _localization![keyName]);
                            }
                            else
                            {
                                if (_settings.ThrowExceptionIfNoValue)
                                    throw new GLocalizationBaseException("There is no key with that name");
                                type.GetProperty(propName).SetValue(viewModel, "");
                            }
                        }
                    }
                }
            }
        }
    }
}
