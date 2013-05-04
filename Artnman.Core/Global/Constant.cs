namespace Artnman.Core.Global
{
    public class Constant
    {
        public const string FORMSTATE_STATE = "State";
        public const string FORMSTATE_SELECTEDID = "SelectedId";
        public const string FORMSTATE_PARENTID = "ParentId";

        public const string ADD = "Add";
        public const string EDIT = "Edit";
        public const string DELETE_SINGLE = "SingleDelete";
        public const string DELETE_GROUP = "GroupDelete";

        public const string GVCOMMAND_EDIT = "EditData";
        public const string GVCOMMAND_DELETE = "DeleteData";
        public const string GVCOMMAND_VIEWCHILD = "ViewChild";

        public const int DEFAULT_PAGE_SIZE = 10;
        public const int DEFAULT_VISIBLE_PAGE_BEFORE_CURRENT_PAGE = 2;

        public const string UPLOAD_PATH_IMAGE = "~/Upload/Image/";
        public const string UPLOAD_PATH_IMAGE_THUMBNAIL = "~/Upload/Image/Thumb";

        public const string DEFAULT_IMAGE = "~/Upload/Image/blank.png";

        public const string PKEY_USER = "Username";

        public const string PKEY_IMAGEALBUM = "ImageAlbumId";
        public const string PKEY_IMAGE = "ImageId";
        public const string PKEY_STATICCONTENT = "StaticContentId";
        public const string PKEY_STATICCONTENTTYPE = "StaticContentTypeId";
        public const string PKEY_SPECIALIMAGETYPE = "SpecialImageTypeId";
        public const string PKEY_SPECIALIMAGE = "SpecialImageId";
        public const string PKEY_SUPPORTTYPE = "SupportTypeId";
        public const string PKEY_SUPPORT = "SupportId";
        public const string PKEY_SLIDESHOWITEM = "SlideshowItemId";

        public const string PKEY_NEWSSTATUS = "NewsStatusId";
        public const string PKEY_NEWSCATEGORY = "NewsCategoryId";
        public const string PKEY_NEWS = "NewsId";
        public const string PKEY_RSSSOURCE = "RssSourceId";
        public const string PKEY_RSSPROVIDER = "RssProviderId";

        public const string PKEY_PRODUCTCATEGORY = "ProductCategoryId";
        public const string PKEY_PRODUCTINFO = "ProductInfoId";

        public const string ROLE_SUPERVISOR = "Supervisor";
        public const string ROLE_ADMINISTRATOR = "Administrator";
    }
}
