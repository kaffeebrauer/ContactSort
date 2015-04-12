using System.Configuration;

namespace GlobalX.Console.ContactSort.Configuration
{
    public class ConfigurationSettingProvider : IConfigurationSettingProvider
    {
        //public string DefaultCulture { get; private set; }
        private const string DefaultCultureSetting = "DefaultCulture";
        private readonly string _defaultCulture;

        public ConfigurationSettingProvider()
        {
            _defaultCulture = ConfigurationManager.AppSettings[DefaultCultureSetting];
        }

        public string DefaultCulture {
            get { return _defaultCulture; }
        }
    }
}
