using System;
using System.Configuration;
using log4net;

namespace Artnman.Core.Utility.Web
{
    public class SettingUtility
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(SettingUtility));

        public static string GenerateAllMetaTags()
        {
            return String.Empty;
        }

        public static string GetStringValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static int GetIntValue(string key)
        {
            int outValue;
            if (!int.TryParse(ConfigurationManager.AppSettings[key], out outValue))
            {
                _logger.Error(":: SettingUtility.GetIntValue | SettingsPropertyWrongTypeException");
            }
            return outValue;
        }

        public static bool GetBoolValue(string key)
        {
            bool outValue;
            if (!bool.TryParse(ConfigurationManager.AppSettings[key], out outValue))
            {
                _logger.Error(":: SettingUtility.GetBoolValue | SettingsPropertyWrongTypeException");
            }
            return outValue;
        }
    }
}
