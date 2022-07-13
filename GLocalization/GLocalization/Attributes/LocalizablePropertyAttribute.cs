using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GLocalization.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizablePropertyAttribute : Attribute
    {
        public string PropertyName { get; }
        public string KeyName { get; }
        /// <summary>
        /// Set the property be able to localize. When a class use Localization.SetLocalization the property that has this attribute automatically will be affected.
        /// </summary>
        /// <param name="keyName">The corresponding key in file If it is same with property name don't need to touch</param>
        /// <param name="propertyName">The property name that uses this attribute, dont need to change</param>
        public LocalizablePropertyAttribute([CallerMemberName] string keyName = "", [CallerMemberName] string propertyName = "")
        {
            PropertyName = propertyName;
            KeyName = keyName;
        }
    }
}
