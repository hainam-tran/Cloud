using Artnman.Core.Extension;

namespace Artnman.Core.Utility.Web
{
    public class UriUtility
    {
        /// <summary>
        /// Checks the access admin location via ReturnUrl in query string.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public static bool CheckAccessAdminLocation(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) return false;
            return returnUrl.Contains("/SiteAdmin/") || returnUrl.Contains("/SiteAdmin");
        }

        public static string MatchUrl(string url, string catId)
        {
            //if (url.Contains(AdjustRootChar(PageDefinition.NEWS_DETAIL)))
            //{
            //    url = AdjustRootChar(PageDefinition.NEWS);
            //    if (!String.IsNullOrEmpty(catId))
            //        url += "?ID=" + catId;
            //}
            //else if (url.Contains(AdjustRootChar(PageDefinition.ITEM_DETAIL)))
            //{
            //    url = AdjustRootChar(PageDefinition.ITEM);
            //    if (!String.IsNullOrEmpty(catId))
            //        url += "?ID=" + catId;
            //}

            return url;
        }

        /// <summary>
        /// Gets the site URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSiteUrl()
        {
            return SettingUtility.GetStringValue("SITE_URL").Trim('/');
        }

        /// <summary>
        /// Generates the friendly URL.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="title">The title.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public static string GenerateFriendlyUrl(string prefix, string extension, object title, object[] ids)
        {
            if (title == null)
            {
                title = string.Empty;
            }

            var tmpTitle = ReplaceVietnameseCharacters(title.ToString().ToLower());

            //Trim Start and End Spaces.
            tmpTitle = tmpTitle.Trim();

            //Trim "-" Hyphen
            tmpTitle = tmpTitle.Trim('-');

            tmpTitle = tmpTitle.ToLower();
            var chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            tmpTitle = tmpTitle.Replace("c#", "C-Sharp");
            tmpTitle = tmpTitle.Replace("vb.net", "VB-Net");
            tmpTitle = tmpTitle.Replace("asp.net", "Asp-Net");

            //Replace . with - hyphen
            tmpTitle = tmpTitle.Replace(".", "-");

            //Replace Special-Characters
            for (var i = 0; i < chars.Length; i++)
            {
                var strChar = chars.GetValue(i).ToString();
                if (tmpTitle.Contains(strChar))
                {
                    tmpTitle = tmpTitle.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            tmpTitle = tmpTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            tmpTitle = tmpTitle.Replace("--", "-");
            tmpTitle = tmpTitle.Replace("---", "-");
            tmpTitle = tmpTitle.Replace("----", "-");
            tmpTitle = tmpTitle.Replace("-----", "-");
            tmpTitle = tmpTitle.Replace("----", "-");
            tmpTitle = tmpTitle.Replace("---", "-");
            tmpTitle = tmpTitle.Replace("--", "-");

            //Run the code again...
            //Trim Start and End Spaces.
            tmpTitle = tmpTitle.Trim();

            //Trim "-" Hyphen
            tmpTitle = tmpTitle.Trim('-');

            //Build SEO Friendly URL
            var newPath = "/";

            if (!string.IsNullOrEmpty(prefix))
                newPath += prefix + "/";

            newPath += tmpTitle + "." + extension;

            if (ids != null)
            {
                foreach (var id in ids)
                {
                    newPath += "/" + id;
                }
            }

            return newPath.ToAbsolutePath();
        }

        public static string GenerateFriendlyUrl(string title)
        {
            if (title == null)
            {
                title = string.Empty;
            }

            var tmpTitle = ReplaceVietnameseCharacters(title.ToLower());

            //Trim Start and End Spaces.
            tmpTitle = tmpTitle.Trim();

            //Trim "-" Hyphen
            tmpTitle = tmpTitle.Trim('-');

            tmpTitle = tmpTitle.ToLower();
            var chars = "$%#@!*?;:~`+=()[]{}|\'<>,/^&.".ToCharArray();
            tmpTitle = tmpTitle.Replace("c#", "C-Sharp");
            tmpTitle = tmpTitle.Replace("vb.net", "VB-Net");
            tmpTitle = tmpTitle.Replace("asp.net", "Asp-Net");

            //Replace . with - hyphen
            tmpTitle = tmpTitle.Replace(".", "-");

            //Replace Special-Characters
            for (var i = 0; i < chars.Length; i++)
            {
                var strChar = chars.GetValue(i).ToString();
                if (tmpTitle.Contains(strChar))
                {
                    tmpTitle = tmpTitle.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            tmpTitle = tmpTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            tmpTitle = tmpTitle.Replace("--", "-");
            tmpTitle = tmpTitle.Replace("---", "-");
            tmpTitle = tmpTitle.Replace("----", "-");
            tmpTitle = tmpTitle.Replace("-----", "-");
            tmpTitle = tmpTitle.Replace("----", "-");
            tmpTitle = tmpTitle.Replace("---", "-");
            tmpTitle = tmpTitle.Replace("--", "-");

            //Run the code again...
            //Trim Start and End Spaces.
            tmpTitle = tmpTitle.Trim();

            //Trim "-" Hyphen
            tmpTitle = tmpTitle.Trim('-');

            //Build SEO Friendly URL
            return tmpTitle;
        }

        /// <summary>
        /// Replaces the vietnamese characters.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static string ReplaceVietnameseCharacters(string title)
        {
            var vChars = @"áàảãạăắằẳẵặâấầẩẫậđéèẻẽẹêếềểễệiíìỉĩịóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựýỳỷỹỵ".ToCharArray();
            var eChars = @"aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiiooooooooooooooooouuuuuuuuuuuuyyyyy".ToCharArray();

            for (var i = 0; i < vChars.Length; i++)
            {
                if (title.IndexOf(vChars[i]) > -1)
                    title = title.Replace(vChars[i], eChars[i]);
            }

            return title;
        }

        public static string GenerateMultiLanguageLink(string languageLink, string pageLink)
        {
            return languageLink + pageLink;
        }
    }
}
