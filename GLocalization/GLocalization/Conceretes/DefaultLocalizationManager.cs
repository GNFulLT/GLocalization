using GLocalization.Abstracts;
using GLocalization.Attributes;
using GLocalization.Exceptions;
using GLocalization.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GLocalization.Conceretes
{
    /// <summary>
    /// The localization manager that has the default localization file. It have to be resource in assembly.
    /// </summary>
    public static class DefaultLocalizationManager
    {
        internal static Dictionary<string, string> DefaultLocalization { get; set; }
        private static bool isInitialized = false;
        private static string filePath = string.Empty;
        /// <summary>
        /// Load the localization assembly file 
        /// </summary>
        /// <param name="resourceFullPath">With Assembly Name example : GLocalization.Resources.defaultLocalization.locale.json</param>
        public static void Init(string resourceFullPath)
        {
            if(isInitialized)
                return;
            try
            {
                Stream defaultLocalizationStream = Assembly.GetCallingAssembly().GetManifestResourceStream($"{resourceFullPath}");
                if (defaultLocalizationStream == null)
                    throw new Exception("Failed to load default localization");
                byte[] defaultLocalizationBuffer = new byte[defaultLocalizationStream.Length];
                defaultLocalizationStream.Read(defaultLocalizationBuffer, 0, defaultLocalizationBuffer.Length);
                //Get File Type
                FileInfo fi = new FileInfo(resourceFullPath);

                IFileType fType = FileType.GetFileTypeByExtension(fi.Extension);

                string fileAsString = Encoding.UTF8.GetString(defaultLocalizationBuffer);

                DefaultLocalization = LangFileDeserializer.Deserialize(fileAsString, fType);
                isInitialized = true;
                filePath = resourceFullPath;
            }
            catch 
            {
                throw;
            }
        }
        /// <summary>
        /// Sets Default Localization
        /// </summary>
        /// <typeparam name="T">Type of first paramater</typeparam>
        /// <param name="obj">The class that has properties with LocalizableProperty attribute</param>
        /// <param name="throwExceptionIfNoValue">Throw an exception if a property doesn't have correspond value in localization file</param>
        /// <exception cref="GLocalizationBaseException">If localization is not initiliazed or found a property that doesn't in localization file</exception>
        public static void SetDefaultLocalization<T>(T obj, bool throwExceptionIfNoValue = true)
        {
            if (DefaultLocalization is null || isInitialized == false)
                throw new GLocalizationBaseException("Localization is not provided");
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
                            string propName = localizationAttr.PropertyName;
                            string keyName = localizationAttr.KeyName;
                            if (DefaultLocalization.ContainsKey(keyName))
                            {
                                type.GetProperty(propName).SetValue(obj, DefaultLocalization[keyName]);
                            }
                            else
                            {
                                if (throwExceptionIfNoValue)
                                    throw new GLocalizationBaseException($"Looked for {keyName} for the property {propName} but couldn't find in the {filePath}");
                                type.GetProperty(propName).SetValue(obj, string.Empty);
                            }
                        }
                    }
                }
            }
        }

    }
}
