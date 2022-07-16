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
have, it will take it from DefaultLocalizationManager. So if you forget to add a key to newly added Localization, it will use the default localization manager to handle
it.

### **Current Supported File Types**
- JSON <br />
- YAML <br />


They are in FileType class. You can use them like : FileType.JSON for settings.

## **How To Use**
Firstly you have to initialize DefaultLocalization file. It have to be embedded resource so in any case application can reference the defaultlocalization. 
Example we have a project like : 


AdminPanel <br />
├── Utilities <br />
│   ├── Builders  <br />
│   └── Readers  <br />
├── Helpers  <br />
│   └── LazyLoaders   <br />
├── Resources  <br />
     └── English.locale.yaml  <br />

Init code will be like : 

```
 DefaultLocalizationManager.Init("AdminPanel.Resources.English.locale.yaml");
```

DefaultLocalizationManager and other managers have protection against to load same data twice. So if you are not sure about loading data, you can use init again.

After that we have to create setting class for our localization managers. Example with singleton design : 

```
 public class GlobalSettings : IGlobalSettings
    {
        public string LocalizationEndPrefix { get; private set; }
        public IFileType FileType { get; private set; }
        public bool ThrowExceptionIfNoValue { get; private set; }
        public string LocalizationFolderPath { get; private set; }
        public ManagerHaveNotOptions IfManagerHaveNotValue { get; private set; }

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        private GlobalSettings()
        {
            LocalizationEndPrefix = "locale";
            FileType = GLocalization.Conceretes.FileType.YAML;
            ThrowExceptionIfNoValue = true;
            LocalizationFolderPath = "Localization";
            IfManagerHaveNotValue = ManagerHaveNotOptions.SetDefault;
        }
    }
```

After that creating our localization manager : 

```
 internal class FrenchLocalizationManager : BaseLocalizationManager
    {
        private const string PREFIX = "France";
        private FrenchLocalizationManager(IGlobalSettings settings) : base(PREFIX, settings)
        { }

        public static FrenchLocalizationManager Instance { get; } = new FrenchLocalizationManager(GlobalSettings.Instance);
    }
```

Prefix : "English"
In settings, endfix : "locale" and our file type yaml so extension will be ".yaml" and our file name will be "French.locale.yaml" Localization folder path is Localization. So our folder hierarcy will be like

AdminPanel  <br />
├── Utilities  <br />
│   ├── Builders  <br />
│   └── Readers  <br />
├── Helpers   <br />
│   └── LazyLoaders   <br />
├── Resources  <br />
     └── English.locale.yaml  <br />
├── Localization  <br />
     └── French.locale.yaml  <br />
     
And French.locale.yaml file's 'Build Action' is Content and 'Copy to Output Direction' is Copy Always. And it is time to use it. Inside the class that we want
to use localization :

```
 public class LoginScreenLoginPanelViewModel : ViewModel
  {
    public LoginScreenLoginPanelViewModel()
    {                
         DefaultLocalizationManager.Init("AdminPanel.Resources.English.locale.yaml");
         FrenchLocalizationManager.Instance.LoadLocalizationData();
         FrenchLocalizationManager.Instance.SetLocalization(this);
    }
    
      #region LocalizableProperties
       [LocalizableProperty]
        public string UsernameHintText { get; set; }

        [LocalizableProperty]
        public string PasswordHintText { get; set; }

        [LocalizableProperty]
        public string LoginButtonText { get; set; }

        [LocalizableProperty]
        public string CreateAccountText { get; set; }

        [LocalizableProperty]
        public string ForgotEmailText{get;set;}

        [LocalizableProperty]
        public string RegisteredText { get; set; }
      #endregion

  }
```

And also we can use Init and LoadLocalizationData after the Application.Run(). You have to init DefaultLocalizationManager firstly.
