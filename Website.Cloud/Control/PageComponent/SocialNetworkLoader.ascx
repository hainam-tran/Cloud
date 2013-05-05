<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialNetworkLoader.ascx.cs"
    Inherits="Website.Cloud.Control.PageComponent.SocialNetworkLoader" %>
<style type="text/css">
    #___plusone_0
    {
        vertical-align: top !important;
        height: 16px !important;
    }
    #___plusone_1
    {
        vertical-align: top !important;
        height: 16px !important;
    }
</style>
<div style="display: inline-block">
    <div style="display: inline-block">
        <a href="http://twitter.com/#!/PyramidVN" target="new_page">
            <img src="/Upload/Image/Content/Icon/twitter_16.png" width="16" height="16" alt="PyramidVN Twitter" /></a>
    </div>
    <div style="display: inline-block">
        <a href="http://www.facebook.com/Artnman" target="new_page">
            <img src="/Upload/Image/Content/Icon/facebook_16.png" width="16" height="16" alt="NamTH FaceBook" /></a>
    </div>
    <img src="/Upload/Image/Content/Icon/google_plus_16.png"
        width="16" height="16" />
    <!-- Place this tag where you want the +1 button to render -->
    <!-- Place this tag where you want the +1 button to render -->
    <%--<g:plusone size="small" annotation="none"></g:plusone>--%>
    <!-- Place this render call where appropriate -->
    <script type="text/javascript">
        (function () {
            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
            po.src = 'https://apis.google.com/js/plusone.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
        })();
    </script>
    <a href="http://www.linkedin.com/pub/pyramid-vietnam/48/a01/128" target="new_page">
        <img src="/Upload/Image/Content/Icon/linkedin_16.png" width="16" height="16" alt="PyramidVN Linkedin" />
    </a>
    <img src="/Upload/Image/Content/Icon/youtube_16.png" width="16" height="16" alt="PyramidVN YouTube" />
</div>
