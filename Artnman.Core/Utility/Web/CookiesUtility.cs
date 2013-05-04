using System;
using System.Web;

namespace Artnman.Core.Utility.Web
{
    public class CookiesUtility
    {
        //private static readonly ILog _logger = LogManager.GetLogger(typeof(CookieUtility));

        /// <summary>
        /// Sets the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="daysToLive">The days to live.</param>
        public static void SetCookie(string name, string value, int daysToLive)
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            var cookie = new HttpCookie(name, value)
            {
                Expires = daysToLive == 0 ? DateTime.MinValue : DateTime.Now.AddDays(daysToLive)
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            if (HttpContext.Current == null)
            {
                return null;
            }

            var httpContext = HttpContext.Current;
            return httpContext.Request.Cookies[name] != null
                ? httpContext.Request.Cookies[name].Value
                : null;
        }

        /// <summary>
        /// Deletes the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        public static void DeleteCookie(string name)
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            var cookie = new HttpCookie(name, string.Empty)
            {
                Expires = DateTime.Now.AddDays(-365)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
