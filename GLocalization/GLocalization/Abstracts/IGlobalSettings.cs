using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Abstracts
{
    /// <summary>
    /// Settings that will be used by Localization Managers. Every Manager can be own their special settings.
    /// </summary>
    public interface IGlobalSettings
    {
        /// <summary>
        /// Folder path that localization manager should lookup to find localization file. It have to be relative path without "./" Example It can be Common/Localization if a localization file like  Common/Localization/English.localization.json
        /// </summary>
        public string LocalizationFolderPath { get; protected set; }

        /// <summary>
        /// Example : English.{LocalizationEndPrefix}.json
        /// </summary>
        public string LocalizationEndPrefix { get; protected set; }

        /// <summary>
        /// The file type that localization manager will read. FileTypes can be select with FileType.
        /// </summary>
        public IFileType FileType {  get; protected set; }

        /// <summary>
        /// If it is false then if a value doesn't exist in json file it will be setted string.empty
        /// </summary>
        public bool ThrowExceptionIfNoValue { get; protected set; }
    }
}
