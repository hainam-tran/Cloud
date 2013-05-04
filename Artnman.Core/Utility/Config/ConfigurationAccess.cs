using System.Configuration;
using Artnman.Core.Service;

namespace Artnman.Core.Utility.Config
{
    public class ConfigurationAccess
    {
        public static string GetConnectionString(string name)
        {
            if (ConfigurationManager.ConnectionStrings[name] != null)
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            else
            {
                return null;
            }
        }

        public static string GetStringValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static int GetIntValue(string key, out OperationResult operationResult)
        {
            int outValue;
            if (!int.TryParse(ConfigurationManager.AppSettings[key], out outValue))
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure };
                return -1;
            }
            operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
            return outValue;
        }

        public static bool GetBoolValue(string key, out OperationResult operationResult)
        {
            bool outValue;
            if (!bool.TryParse(ConfigurationManager.AppSettings[key], out outValue))
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure };
                return false;
            }
            operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
            return outValue;
        }

        //public static string GenerateAllMetaTags()
        //{
        //    var metaTag = "<meta name=\"description\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_DESCRIPTION) + "\" />\n";
        //    metaTag += "<meta name=\"keywords\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_KEYWORDS) + "\" />\n";
        //    metaTag += "<meta name=\"generator\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_GENERATOR) + "\" />\n";
        //    metaTag += "<meta name=\"copyright\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_COPYRIGHT) + "\" />\n";
        //    metaTag += "<meta name=\"author\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_AUTHOR) + "\" />\n";
        //    metaTag += "<meta name=\"publisher\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_PUBLISHER) + "\" />\n";
        //    metaTag += "<meta name=\"page-topic\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_PAGE_TOPIC) + "\" />\n";
        //    metaTag += "<meta name=\"page-type\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_PAGE_TYPE) + "\" />\n";
        //    metaTag += "<meta name=\"audience\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_AUDIENCE) + "\" />\n";
        //    metaTag += "<meta name=\"expires\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_EXPIRES) + "\" />\n";
        //    metaTag += "<meta name=\"robots\" content=\"" + GetStringValue(Constant.APPSETTINGS_SITE_META_TAG_ROBOTS) + "\" />\n";
        //    return metaTag;
        //}
    }
}
