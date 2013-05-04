using System;
using System.Web.Security;
using System.Web.UI;
using Artnman.Core.Global;
using Artnman.Core.Service;
using Artnman.Core.Setting;
using Artnman.Core.Utility.Web;

namespace Artnman.Core.Base
{
    public class BasePage : Page
    {
        public static OperationResult operationResult;
        #region PROPERTIES

        private string _uiLanguageId = string.Empty;
        private string _languageId = string.Empty;
        private string _siteUrl = string.Empty;
        private MembershipUser _currentUser;

        /// <summary>
        /// Gets the site URL.
        /// </summary>
        public virtual string SiteUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_siteUrl))
                {
                    _siteUrl = UriUtility.GetSiteUrl();
                }
                return _siteUrl;
            }
        }

        /// <summary>
        /// Gets or sets the UI language id.
        /// </summary>
        /// <value>
        /// The UI language id.
        /// </value>
        public virtual string UILanguageId
        {
            get
            {
                if (string.IsNullOrEmpty(_uiLanguageId))
                {
                    _uiLanguageId = LanguageUtility.GetCurrentUILanguage();
                }
                return _uiLanguageId;
            }
            set
            {
                _uiLanguageId = value;
            }
        }

        /// <summary>
        /// Gets or sets the language id.
        /// </summary>
        /// <value>
        /// The language id.
        /// </value>
        public virtual string LanguageId
        {
            get
            {
                if (string.IsNullOrEmpty(_languageId))
                {
                    _languageId = LanguageUtility.GetCurrentLanguage();
                }
                return _languageId;
            }
            set
            {
                _languageId = value;
            }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        public virtual MembershipUser CurrentUser
        {
            get
            {
                return _currentUser ?? (_currentUser = UserUtility.GetCurrentUser());
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Sets the <see cref="P:System.Web.UI.Page.Culture"/> and <see cref="P:System.Web.UI.Page.UICulture"/> for the current thread of the page.
        /// </summary>
        protected override void InitializeCulture()
        {
            var culture = LanguageUtility.GetCurrentUILanguage();
            UILanguageId = culture;

            if (String.IsNullOrEmpty(culture))
            {
                culture = "Auto";
            }

            Page.UICulture = culture;
            Page.Culture = culture;
            if (culture != "Auto")
            {
                var ci = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }

            base.InitializeCulture();
        }

        public void InitPageLanguage()
        {
            if (Request.QueryString["language"] == null)
            {
                Page.Response.Redirect("/" + LanguageSetting.Setting.DefaultLanguage.Substring(0, 2) + PageDefinition.FE_HOME);
            }
            var language = Request.QueryString["language"];
            if (language.Equals(LanguageUtility.GetCurrentLanguage().Substring(0, 2))) return;
            if (language.Equals(LanguageSetting.Setting.DefaultLanguage.Substring(0, 2)))
            {
                LanguageUtility.SetCurrentUILanguage(LanguageSetting.Setting.DefaultLanguage);
                LanguageUtility.SetCurrentLanguage(LanguageSetting.Setting.DefaultLanguage);
                Page.Response.Redirect(Request.Url.AbsolutePath, true);
            }
            else
            {
                LanguageUtility.SetCurrentUILanguage(LanguageSetting.Setting.SecondLanguage);
                LanguageUtility.SetCurrentLanguage(LanguageSetting.Setting.SecondLanguage);
                Page.Response.Redirect(Request.Url.AbsolutePath, true);
            }
        }

        #endregion
    }
}
