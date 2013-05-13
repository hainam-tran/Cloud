using System.Web.Optimization;

/// <summary>
/// Summary description for BundleConfig
/// </summary>
public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        // for anonymous users
        bundles.Add(new StyleBundle("~/Blog/Content/Auto/css").Include(
            "~/Blog//Content/Auto/*.css")
        );
        bundles.Add(new ScriptBundle("~/Blog/Scripts/Auto/js").Include(
            "~/Blog//Scripts/Auto/*.js")
        );

        // for authenticated users
        bundles.Add(new StyleBundle("~/Blog/Content/Auto/cssauth").Include(
            "~/Blog/Content/Auto/*.css",
            "~/Blog/Modules/QuickNotes/Qnotes.css")
        );
        bundles.Add(new ScriptBundle("~/Blog/Scripts/Auto/jsauth").Include(
            "~/Blog/Scripts/Auto/*.js")
        );

        // administration
        bundles.Add(new StyleBundle("~/Blog/admin/css").Include(
            "~/Blog/admin/style.css",
            "~/Blog/admin/colorbox.css",
            "~/Blog/admin/tipsy.css")
        );
        bundles.Add(new ScriptBundle("~/Blog/Scripts/adminjs").Include(
            "~/Blog/Scripts/jquery-1.8.2.js",
            "~/Blog/Scripts/jquery.cookie.js",
            "~/Blog/Scripts/jquery.validate.js",
            "~/Blog/Scripts/jquery-jtemplates.js",
            "~/Blog/admin/admin.js")
        );

        // syntax highlighter 
        var shRoot = "~/Blog/editors/tiny_mce_3_5_8/plugins/syntaxhighlighter/";
        bundles.Add(new StyleBundle("~/Blog/Content/highlighter").Include(
            shRoot + "styles/shCore.css",
            shRoot + "styles/shThemeDefault.css")
        );
        bundles.Add(new ScriptBundle("~/Blog/Scripts/highlighter").Include(
            shRoot + "scripts/XRegExp.js",
            shRoot + "scripts/shCore.js",
            shRoot + "scripts/shAutoloader.js",
            shRoot + "shActivator.js")
        );

        // syntax FileManager 
        bundles.Add(new StyleBundle("~/Blog/Content/filemanager").Include(
            "~/Blog/admin/FileManager/FileManager.css",
            "~/Blog/admin/uploadify/uploadify.css",
            "~/Blog/admin/FileManager/jqueryui/jquery-ui.css",
            "~/Blog/admin/FileManager/JCrop/css/jquery.Jcrop.css")
        );
        bundles.Add(new ScriptBundle("~/Blog/Scripts/filemanager").Include(
            "~/Blog/admin/uploadify/swfobject.js",
            "~/Blog/admin/uploadify/jquery.uploadify.v2.1.4.min.js",
            "~/Blog/admin/FileManager/jqueryui/jquery-ui.min.js",
            "~/Blog/admin/FileManager/jquery.jeegoocontext.min.js",
            "~/Blog/admin/FileManager/JCrop/js/jquery.Jcrop.min.js",
            "~/Blog/admin/FileManager/FileManager-mini.js")
        );

    }
}