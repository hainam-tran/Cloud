using System.Configuration;

namespace Artnman.Core.Setting
{
    public class LanguageSetting : ConfigurationSection
    {
        private static readonly LanguageSetting _setting = ConfigurationManager.GetSection("languageSetting") as LanguageSetting;

        public static LanguageSetting Setting
        {
            get
            {
                return _setting;
            }
        }

        [ConfigurationProperty("defaultLanguage", DefaultValue = "vi-VN", IsRequired = true)]
        public string DefaultLanguage
        {
            get { return this["defaultLanguage"].ToString(); }
            set { this["defaultLanguage"] = value; }
        }

        [ConfigurationProperty("secondLanguage", DefaultValue = "en-US", IsRequired = true)]
        public string SecondLanguage
        {
            get { return this["secondLanguage"].ToString(); }
            set { this["secondLanguage"] = value; }
        }
    }
}
