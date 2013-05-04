namespace Artnman.Core.Global
{
    public class PageDefinition
    {
        /** Back-end */
        public const string ADMIN_HOME = "~/Administrator/Home.aspx";
        public const string ADMIN_USER_LOGIN = "~/Administrator/SignIn.aspx";
        public const string ADMIN_SYSTEM_CONFIGURATION = "~/SiteAdmin/Pages/SystemConfiguration.aspx";

        /** Error */
        public const string ERROR_BAD_REQUEST = "~/error.aspx?c=400";
        public const string ERROR_FORBIDDEN = "~/error.aspx?c=403";
        public const string ERROR_INTERNAL_SERVER_ERROR = "~/error.aspx?c=500";
        public const string ERROR_INVALID_LICENSE = "~/error.aspx?c=InvalidLicense";
        public const string ERROR_INVALID_PARAMETER = "~/error.aspx?c=InvalidParameter";
        public const string ERROR_NOT_FOUND = "~/error.aspx?c=404";
        public const string ERROR_REQUEST_TIMEOUT = "~/error.aspx?c=408";
        public const string ERROR_UNAUTHORIZED = "~/error.aspx?c=401";
        public const string ERROR_UNDER_CONSTRUCTION = "~/error.aspx?c=UnderConstruction";

        /** Front-end */
        public const string USER_LOGIN = "~/user/login.aspx";
        public const string FE_HOME = "/Home.aspx";
        public const string FE_ABOUTUS = "/AboutUs.aspx";
        public const string FE_CONTACTUS = "/Contact.aspx";
        public const string FE_PROJECT = "/Projects.aspx";
        public const string FE_RECUITMENT = "/Recuitment.aspx";
        public const string FE_SEARCH = "/Search.aspx";
        public const string FE_NEWSCATEGORY = "/NewsCategory/";
        public const string FE_NEWS= "/News/";
        public const string FE_NEWS_STATIC = "/News.aspx";
        public const string FE_SERVICE = "/Services/";
        public const string FE_SOLUTION= "/Solutions/";
        public const string FE_PRODUCTS = "/Products/";
        public const string FE_PRODUCTCATEGORIES1 = "/ProductCategories.aspx";
        public const string FE_PRODUCTCATEGORIES2 = "/ProductCategories/";
        public const string FE_PRODUCTDETAILS = "/ProductDetails/";
        public const string FE_PRODUCTSEARCH = "/SearchProduct/";
        public const string FE_UPDATING = "/Updating.aspx";

        public const string FRONT_END_UD = "~/Pages/UC/index.html";
    }
}
