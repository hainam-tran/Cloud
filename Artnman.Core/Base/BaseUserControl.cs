using System.Web.Security;
using System.Web.UI;
using Artnman.Core.Service;

namespace Artnman.Core.Base
{
    /// <summary>
    /// Base class for user controls
    /// Note: Parent page must be type of BasePage to use properties
    /// </summary>
    public class BaseUserControl : UserControl
    {
        #region PROPERTIES
        public static OperationResult operationResult;
        private BasePage _parentPage;
        private BasePageListTable _parentBasePageListTablePage;

        /// <summary>
        /// Gets the parent page.
        /// </summary>
        protected BasePage ParentPage
        {
            get { return _parentPage ?? (_parentPage = (BasePage)Page); }
        }

        /// <summary>
        /// Gets the parent list table page.
        /// </summary>
        protected BasePageListTable ParentBasePageListTablePage
        {
            get { return _parentBasePageListTablePage ?? (_parentBasePageListTablePage = (BasePageListTable)Page); }
        }

        /// <summary>
        /// Gets the site URL.
        /// </summary>
        protected virtual string SiteUrl
        {
            get { return ParentPage.SiteUrl; }
        }

        /// <summary>
        /// Gets or sets the UI language id.
        /// </summary>
        /// <value>
        /// The UI language id.
        /// </value>
        protected virtual string UILanguageId
        {
            get { return ParentPage.UILanguageId; }
            set { ParentPage.UILanguageId = value; }
        }

        /// <summary>
        /// Gets the language id.
        /// </summary>
        protected virtual string LanguageId
        {
            get { return ParentPage.LanguageId; }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        protected virtual MembershipUser CurrentUser
        {
            get { return ParentPage.CurrentUser; }
        }

        #endregion
    }
}
