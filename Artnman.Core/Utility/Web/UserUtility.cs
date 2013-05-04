using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Artnman.Core.Global;

namespace Artnman.Core.Utility.Web
{
    public class UserUtility
    {
        /// <summary>
        /// Gets the current membership user.
        /// </summary>
        /// <returns></returns>
        public static MembershipUser GetCurrentUser()
        {
            // Case : SUPERVISOR
            var httpContent = HttpContext.Current;
            if (httpContent.Session[(string)SessionKey.KEY_SUPERVISOR] != null &&
                httpContent.Session[(string)SessionKey.KEY_SUPERVISOR_USER] != null)
            {
                // Get supervisor user
                return httpContent.Session[(string)SessionKey.KEY_SUPERVISOR_USER] as MembershipUser;
            }
            // Get normal membership user
            return Membership.GetUser();
        }
    }
}
