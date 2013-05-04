<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JavaScriptLoader.ascx.cs"
    Inherits="Website.Cloud.Control.JavaScriptLoader" %>
<script type="text/javascript" src="/Include/js/Common/jquery-1.8.1.min.js"></script>
<script type="text/javascript" src="/Include/Bootstrap/js/bootstrap.min.js"></script>
<%--//Google +1 Button
     ================================================--%>
<script type="text/javascript">
    (function () {
        var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
        po.src = 'https://apis.google.com/js/plusone.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
    })();
</script>