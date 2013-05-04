using Artnman.Core.Global;
using Artnman.Core.Setting;

namespace Artnman.Core.Utility.Web
{
    public class LanguageUtility
    {
        /// <summary>
        /// Gets the current language.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguage()
        {
            return !string.IsNullOrEmpty(CookiesUtility.GetCookie(SessionKey.KEY_LANGUAGE))
               ? CookiesUtility.GetCookie(SessionKey.KEY_LANGUAGE)
               : GetLanguageByDefault();

        }

        /// <summary>
        /// Gets the current admin language.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentAdminLanguage()
        {
            return !string.IsNullOrEmpty(CookiesUtility.GetCookie(SessionKey.KEY_ADMIN_LANGUAGE))
                ? CookiesUtility.GetCookie(SessionKey.KEY_ADMIN_LANGUAGE)
                : GetAdminLanguageByDefault();
        }

        /// <summary>
        /// Gets the current UI language.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUILanguage()
        {
            return !string.IsNullOrEmpty(CookiesUtility.GetCookie(SessionKey.KEY_UI_LANGUAGE))
                ? CookiesUtility.GetCookie(SessionKey.KEY_UI_LANGUAGE)
                : GetLanguageByDefault();
        }

        /// <summary>
        /// Gets the current admin UI language.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentAdminUILanguage()
        {
            return !string.IsNullOrEmpty(CookiesUtility.GetCookie(SessionKey.KEY_ADMIN_UI_LANGUAGE))
                ? CookiesUtility.GetCookie(SessionKey.KEY_ADMIN_UI_LANGUAGE)
                : GetAdminLanguageByDefault();
        }

        /// <summary>
        /// Gets the default language.
        /// </summary>
        /// <returns></returns>
        public static string GetLanguageByDefault()
        {
            //var entity = LanguageFactory.Instance.GetByDefault();
            //if (entity != null)
            //{
            //    CookiesUtility.SetCookie(SessionKey.KEY_LANGUAGE, entity.Id, 7);
            //    CookiesUtility.SetCookie(SessionKey.KEY_UI_LANGUAGE, entity.Id, 7);
            //}
            CookiesUtility.SetCookie(SessionKey.KEY_LANGUAGE, LanguageSetting.Setting.DefaultLanguage, 7);
            CookiesUtility.SetCookie(SessionKey.KEY_UI_LANGUAGE, LanguageSetting.Setting.DefaultLanguage, 7);
            return string.Empty;
        }

        /// <summary>
        /// Gets the default admin language.
        /// </summary>
        /// <returns></returns>
        public static string GetAdminLanguageByDefault()
        {
            //var entity = LanguageFactory.Instance.GetByDefault();
            //if (entity != null)
            //{
            //    CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_LANGUAGE, entity.Id, 7);
            //    CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_UI_LANGUAGE, entity.Id, 7);
            //}
            CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_LANGUAGE, LanguageSetting.Setting.DefaultLanguage, 7);
            CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_UI_LANGUAGE, LanguageSetting.Setting.DefaultLanguage, 7);
            return string.Empty;
        }

        /// <summary>
        /// Sets the current language.
        /// </summary>
        /// <param name="languageId">The language id.</param>
        public static void SetCurrentLanguage(string languageId)
        {
            CookiesUtility.SetCookie(SessionKey.KEY_LANGUAGE, languageId, 7);
        }

        /// <summary>
        /// Sets the current admin language.
        /// </summary>
        /// <param name="languageId">The language id.</param>
        public static void SetCurrentAdminLanguage(string languageId)
        {
            CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_LANGUAGE, languageId, 7);
        }

        /// <summary>
        /// Sets the current UI language.
        /// </summary>
        /// <param name="uiLanguageId">The UI language id.</param>
        public static void SetCurrentUILanguage(string uiLanguageId)
        {
            CookiesUtility.SetCookie(SessionKey.KEY_UI_LANGUAGE, uiLanguageId, 7);
        }

        /// <summary>
        /// Sets the current admin UI language.
        /// </summary>
        /// <param name="uiLanguageId">The UI language id.</param>
        public static void SetCurrentAdminUILanguage(string uiLanguageId)
        {
            CookiesUtility.SetCookie(SessionKey.KEY_ADMIN_UI_LANGUAGE, uiLanguageId, 7);
        }

    }
}
