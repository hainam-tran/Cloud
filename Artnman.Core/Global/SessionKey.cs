using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artnman.Core.Global
{
    public class SessionKey
    {
        /** License file */
        public const string KEY_LICENSE = "Artnman:License";

        /** Users */
        public const string KEY_SUPERVISOR = "Artnman:Supervisor";
        public const string KEY_SUPERVISOR_USER = "Artnman:SupervisorUser";
        public const string KEY_USER = "Artnman:User";

        /** Language */
        public const string KEY_ADMIN_LANGUAGE = "Artnman:AdminLanguage";
        public const string KEY_LANGUAGE = "Artnman:Language";
        public const string KEY_ADMIN_UI_LANGUAGE = "Artnman:AdminUILanguage";
        public const string KEY_UI_LANGUAGE = "Artnman:UILanguage";

        /** Upload file */
        public const string KEY_IMAGE_UPLOADED = "Artnman:UploadedImage";
        public const string KEY_FILE_UPLOADED = "Artnman:UploadedFile";

        /** Category */
        public const string KEY_CATEGORY = "Artnman:Category";

        /** Menu */
        public const string KEY_MENU = "Artnman:Menu";

        /** Redirect link when login*/
        public const string KEY_REDIRECT_LINK = "Artnman:RedirectLink";

    }
}
