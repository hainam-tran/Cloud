using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Artnman.Core.Extension
{
    public static class PageExtension
    {
        /// <summary>
        /// Register the client script file with this page using key and file relative path
        /// </summary>
        /// <param name="page">The page</param>
        /// <param name="key">The unique key identify the script. If provides an existed key, nothing will be registered</param>
        /// <param name="rootRelativePath">relative path of the file</param>
        public static void RegisterClientScriptFile(this Page page, string key, string rootRelativePath)
        {
            page.ClientScript.RegisterClientScriptInclude(key, rootRelativePath);
        }

        /// <summary>
        /// Register the CSS file to the header of this page, using key and file relative path.
        /// This function only works with serverside header of HTML page. Otherwise, it will do nothing.
        /// </summary>
        /// <param name="page">the page</param>
        /// <param name="key">the unique key identify the css file. If provides an existed key, nothing will be registered</param>
        /// <param name="rootRelativePath">relative path of the file</param>
        public static void RegisterCssFile(this Page page, string key, string rootRelativePath)
        {
            // if the style is not registered under key, we register it once
            if (page.Header != null && page.Header.FindControl(key) == null)
            {
                var link = new HtmlLink { ID = key };
                link.Attributes.Add("href", rootRelativePath);
                link.Attributes.Add("rel", "stylesheet");
                link.Attributes.Add("type", "text/css");
                page.Header.Controls.Add(link);
            }
        }

        /// <summary>
        /// Set title for this page
        /// </summary>
        /// <param name="page">the page</param>
        /// <param name="title">the title for the page</param>
        public static void SetTitle(this Page page, string title)
        {
            page.Title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="title"></param>
        public static void SetPageTitle(this Page page, string title)
        {
            var lblPageTitle = page.FindControlRecursive("lblPageTitle") as System.Web.UI.WebControls.Label;
            if (lblPageTitle != null)
                lblPageTitle.Text = title;
        }

        public static void ShowError(this Page page, string errMessage, string errStackTrace)
        {
            var pnlError = page.FindControlRecursive("pnlError") as System.Web.UI.WebControls.Panel;
            var lblError = page.FindControlRecursive("lblError") as System.Web.UI.WebControls.Label;
            var lblStackTrace = page.FindControlRecursive("lblStackTrace") as System.Web.UI.WebControls.Label;
            if (pnlError != null) pnlError.Visible = true;
            if (lblError != null) lblError.Text = errMessage;
            if (lblStackTrace != null) lblStackTrace.Text = errStackTrace;
        }

        /// <summary>
        /// Register the meta tag for this page
        /// </summary>
        /// <param name="page">the page</param>
        /// <param name="name">the meta tag name</param>
        /// <param name="content">the meta tag content</param>
        public static void RegisterMetaTag(this Page page, string name, string content)
        {
            var tag = new HtmlMeta
                          {
                              Name = name,
                              Content = content
                          };
            page.Header.Controls.Add(tag);
        }

        /// <summary>
        /// Register the meta tag for this page
        /// </summary>
        /// <param name="page">the page</param>
        /// <param name="name">the meta tag name attribute</param>
        /// <param name="content">the meta tag content attribute</param>
        /// <param name="httpEquiv">the meta tag httpEquiv attribute</param>
        /// <param name="scheme">the meta tag scheme attribute</param>
        public static void RegisterMetaTag(this Page page, string name, string content, string httpEquiv, string scheme)
        {
            var tag = new HtmlMeta
                          {
                              Name = name,
                              Content = content,
                              HttpEquiv = httpEquiv,
                              Scheme = scheme
                          };
            page.Header.Controls.Add(tag);
        }

        /// <summary>
        /// Shows the message with default message type 'Notice'
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="messageContent">Content of the message.</param>
        public static void ShowMessage(this Page page, string messageContent)
        {
            ShowMessage(page, messageContent, Global.Enum.MessageType.Notice);
        }

        /// <summary>
        /// Shows the message in default message container 'oo-messageContainer"
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="messageType">Type of the message.</param>
        public static void ShowMessage(this Page page, string messageContent, Global.Enum.MessageType messageType)
        {
            var pnlMessage = page.FindControlRecursive("pnlMessage") as System.Web.UI.WebControls.Panel;
            var liMessage = new System.Web.UI.WebControls.Literal
                                {
                                    Text =
                                        @"<div id=""wNv-messageContainer"" class=""" + messageType.ToString().ToLower() +
                                        @""" style=""display: inline-block; "">" + messageContent + @"</div>"
                                };
            if (pnlMessage != null) pnlMessage.Controls.Add(liMessage);
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageContainerId">The message container id.</param>
        public static void ShowMessage(this Page page, string messageContent, Global.Enum.MessageType messageType,
                                       string messageContainerId)
        {
            var callScript = string.Format(
                "<script type=\"text/javascript\">showMessage('{0}', '{1}', '{2}')</script>", messageContent,
                messageType.ToString().ToLower(), messageContainerId);
            page.ClientScript.RegisterStartupScript(page.GetType(), "showMessage", callScript);
        }

        public static Control FindControlRecursive(this Control ctrl, string controlID)
        {
            switch (string.Compare(ctrl.ID, controlID, true))
            {
                case 0:
                    return ctrl;
                default:
                    return
                        (from Control child in ctrl.Controls select FindControlRecursive(child, controlID)).
                            FirstOrDefault(lookFor => lookFor != null);
            }
        }
    }
}