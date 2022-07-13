# **GLocalization**

This library will help you to handle localization easily in your project. Written with .NET Standart 2.0.0 So you can use in .Net Framework 4.6.1-4.8, 
.Net Core 2.0-6.0 etc. platforms. Primarily designed for MVVM architecture.


## **How It Works**
Firstly, you need to write specific language texts to a file with key and coresspond value. And GLocalization convert them to properties so you can integrate them
to UI easily. 

### BaseLocalizationManager
If you want to add English UI's for your project Simply you can create EnglishLocalizationManager that extends BaseLocalizationManager. And you give two paramaters to
LocalizationManagers. These are prefix and a GlobalSettings. Prefix, it defines itself in this example it will be like "English" or "english". This the prefix of 
file. Thinks that a file like that "English.locale.json". English is prefix locale is endfix and json is filetype extension.

### IGlobalSettings
The GlobalSettings paramater will be extends this interface. This interface contains necessarily properties for Localization Manager.

### DefaultLocalizationManager
Every program needs a default localization for UI and this class is responsible to handle it. If Localization manager doesn't have a key that DefaultLocalizationManager
have, it will be take it from DefaultLocalizationManager. So if you forget to add a key to newly added Localization, it will use the default localization manager to handle
it.

### **Current Supported File Types**
- JSON <br />


These are in FileType class. You can use them like : FileType.JSON for settings.
