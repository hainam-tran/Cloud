using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Artnman.Core.Utility.Web;

namespace Artnman.Core.Extension
{
    public static class StringExtension
    {
        // Default shorten string tail
        private const string DEFAULT_TAIL = "...";
        // Default shorten string size
        private const int DEFAULT_SIZE = 50;

        /// <summary>
        /// Get the string that is suitable to display on web page
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The encoded string</returns>
        public static string ToHtmlEncoded(this string source)
        {
            return HttpUtility.HtmlEncode(source);
        }

        /// <summary>
        /// Get the string that is suitable to use in client script
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The encoded string</returns>
        public static string ToJavaScriptEncoded(this string source)
        {
            if (source == null)
            {
                return string.Empty;
            }
            var builder = new StringBuilder(source);
            builder.Replace(@"\", @"\\");
            builder.Replace("\"", "\\\"");
            builder.Replace("'", @"\'");
            builder.Replace("\r", @"\r");
            builder.Replace("\n", @"\n");
            builder.Replace("\t", @"\t");
            return Regex.Replace(builder.ToString(), @"</\s*script\s*>", @"<\/script>", RegexOptions.IgnoreCase);

        }

        /// <summary>
        /// Get the string that is suitable to display on url
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The encoded string</returns>
        public static string ToUrlEncoded(this string source)
        {
            return HttpUtility.UrlPathEncode(source);
        }

        /// <summary>
        /// Shorten the string that exceeds a maxSize
        /// Truncate the string by characters
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The shorten string</returns>
        public static string ToShortenString(this string source)
        {
            return source.ToShortenString(DEFAULT_SIZE, true);
        }

        /// <summary>
        /// Shorten the string that exceeds a maxSize
        /// Truncate the string by characters
        /// <remarks>
        /// If maxsize less or equal 3, we cannot use tail as triple dots.
        /// If source.Length is less than maxSize, we leave the sourse string unchanged.
        /// </remarks>
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="maxSize">Max size of the returned string. If maxSize is negative, return string.Empty</param>
        /// <param name="useTail">Indicate to use trailing ... (triple dots) or not</param>
        /// <returns>The shorten string</returns>
        public static string ToShortenString(this string source, int maxSize, bool useTail)
        {
            if (maxSize <= 0)
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(source) && source.Length > maxSize)
            {
                source = useTail && (maxSize > DEFAULT_TAIL.Length)
                             ? source.Substring(0, maxSize - DEFAULT_TAIL.Length) + DEFAULT_TAIL
                             : source.Substring(0, maxSize);
            }
            return source;
        }

        /// <summary>
        /// Shorten the string that exceeds a maxSize
        /// Truncate the string by words
        /// <remarks>
        /// If maxsize less or equal 3, we cannot use tail as triple dots.
        /// If source.Length is less than maxSize, we leave the sourse string unchanged.
        /// </remarks>
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="maxSize">Max size of the returned string. If maxSize is negative, return string.Empty</param>
        /// <param name="keepWord">Indicate to keep each word of the source string</param>
        /// <param name="useTail">Indicate to use trailing ... (triple dots) or not</param>
        /// <returns>The shorten string</returns>
        public static string ToShortenString(this string source, int maxSize, bool keepWord, bool useTail)
        {
            if (maxSize <= 0)
            {
                return string.Empty;
            }
            if (!keepWord)
            {
                return ToShortenString(source, maxSize, useTail);
            }
            if (!string.IsNullOrEmpty(source) && source.Length > maxSize)
            {
                var words = source.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                source = string.Empty;

                foreach (var w in words.Where(w => source.Length + DEFAULT_TAIL.Length <= maxSize))
                {
                    source += w + " ";
                }
                if (useTail && (maxSize > DEFAULT_TAIL.Length))
                {
                    source = source.Trim() + DEFAULT_TAIL;
                }
            }
            return source;
        }

        /// <summary>
        /// Gets the absolute path.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string ToAbsolutePath(this string source)
        {
            return string.Join("/", new[] { UriUtility.GetSiteUrl(), source.RemoveRootChar().TrimStart('/') });
        }

        /// <summary>
        /// Removes the root char.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string RemoveRootChar(this string source)
        {
            return source.TrimStart('~');
        }

        /// <summary>
        /// Remove Html tags and unnecessary scripts from a Html content string.
        /// </summary>
        /// <param name="source">Specifies the string containing the HTML content.</param>
        /// <returns>Plain text from the HTML content string.</returns>
        public static string StripHtmlTags(this string source)
        {
            var output = source;

            // remove invisible content
            var searchFor = new[]
            {
                "<head[^>]*?>.*?</head>",
                "<style[^>]*?>.*?</style>",
                "<script[^>]*?.*?</script>",
                "<object[^>]*?.*?</object>",
                "<embed[^>]*?.*?</embed>",
                "<applet[^>]*?.*?</applet>",
                "<noframes[^>]*?.*?</noframes>",
                "<noscript[^>]*?.*?</noscript>",
                "<noembed[^>]*?.*?</noembed>",
            };
            output = searchFor.Aggregate(output, (current, search) => Regex.Replace(current, search, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant));

            // add line break before and after blocks to prevent word joining
            searchFor = new[] {            
                "</?((address)|(blockquote)|(center)|(del))",
                "</?((div)|(h[1-9])|(ins)|(isindex)|(p)|(pre))",
                "</?((dir)|(dl)|(dt)|(dd)|(li)|(menu)|(ol)|(ul))",
                "</?((table)|(th)|(td)|(caption))",
                "</?((form)|(button)|(fieldset)|(legend)|(input))",
                "</?((label)|(select)|(optgroup)|(option)|(textarea))",
                "</?((frameset)|(frame)|(iframe))"
            };
            output = searchFor.Aggregate(output, (current, search) => Regex.Replace(current, search, "\r\n$0", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));

            // strip tags
            output = Regex.Replace(output, @"<[^>]*>", string.Empty);

            // remove extra spaces
            output = Regex.Replace(output, @"\s{2,}", " ");
            output = Regex.Replace(output, @"(\t){2,}", " ");
            output = Regex.Replace(output, @"(\r\n){2,}", " ");
            output = Regex.Replace(output, @"(\r|\n){2,}", "\n");

            return output;
        }

        public static string ToMD5Encrypted(this string phrase)
        {
            var encoder = new UTF8Encoding();
            var md5Hasher = new MD5CryptoServiceProvider();
            var hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }

        public static string ToSHA1Encrypted(this string phrase)
        {
            var encoder = new UTF8Encoding();
            var sha1Hasher = new SHA1CryptoServiceProvider();
            var hashedDataBytes = sha1Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }

        public static string ToSHA256Encrypted(this string phrase)
        {
            var encoder = new UTF8Encoding();
            var sha256Hasher = new SHA256Managed();
            var hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }

        public static string ToSHA384Encrypted(this string phrase)
        {
            var encoder = new UTF8Encoding();
            var sha384Hasher = new SHA384Managed();
            var hashedDataBytes = sha384Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }

        public static string ToSHA512Encrypted(this string phrase)
        {
            var encoder = new UTF8Encoding();
            var sha512Hasher = new SHA512Managed();
            var hashedDataBytes = sha512Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }


        #region PRIVATE METHODS

        private static string ByteArrayToString(byte[] inputArray)
        {
            var output = new StringBuilder("");
            for (var i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

        #endregion
    }
}
