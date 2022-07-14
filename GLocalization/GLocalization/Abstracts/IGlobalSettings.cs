using System;
using System.Collections.Generic;
using System.Text;

namespace GLocalization.Abstracts
{
    /// <summary>
    /// What will be happen if manager doesn't have a key that default manager have
    /// </summary>
    public enum ManagerHaveNotOptions
    {
        /// <summary>
        /// Set the value string.empty
        /// </summary>
        SetEmpty,
        /// <summary>
        /// Set the value default localization
        /// </summary>
        SetDefault,
        /// <summary>
        /// Throw an exception
        /// </summary>
        ThrowExcept
    }
    /// <summary>
    /// Settings that will be used by Localization Managers. Every Manager can be own their special settings.
    /// </summary>
    public interface IGlobalSettings
    {
        /// <summary>
        /// Folder path that localization manager should lookup to find localization file. It have to be relative path without "./" Example It can be Common/Localization if a localization file like  Common/Localization/English.localization.json
        /// </summary>
         string LocalizationFolderPath { get; }

        /// <summary>
        /// Example : English.{LocalizationEndPrefix}.json
        /// </summary>
         string LocalizationEndPrefix { get; }

        /// <summary>
        /// The file type that localization manager will read. FileTypes can be select with FileType.
        /// </summary>
         IFileType FileType {  get; }

        /// <summary>
        /// If it is false then if a value doesn't exist in json file it will be setted string.empty
        /// </summary>
         bool ThrowExceptionIfNoValue { get; }

        /// <summary>
        /// What will be happen if manager doesn't have a key that default manager have
        /// </summary>
        ManagerHaveNotOptions IfManagerHaveNotValue { get; }
    }
}
