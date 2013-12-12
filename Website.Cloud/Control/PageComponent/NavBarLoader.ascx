<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarLoader.ascx.cs"
    Inherits="Website.Cloud.Control.PageComponent.NavBarLoader" %>
<script type="text/javascript">
    $(document).ready(function () {
        var myList = [];
        myList.push(document.getElementById('slQuicklinks'));
        for (var i = 0; i < myList.length; i++)
            myList[i].onchange = function () {
                if (this.options[this.selectedIndex].value != this.options[this.selectedIndex].text) {
                    window.open(this.options[this.selectedIndex].value);
                }
            };
        var num = ($(document).width() - 968) / 2 + 50;
        var strDocWidth = num.toString() + "px";
        $(document.getElementById('divOffset')).css("margin-left", strDocWidth);
    });
</script>
<div class="row-fluid">
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <div id="divOffset">
                <ul class="nav navbar-nav">
                    <li><a href="/Default.aspx">Home</a></li>
                    <li><a href="/Page/CV.aspx">A short CV</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dissemination<b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a tabindex="-1" href="/Page/Publication.aspx">Publication</a></li>
                            <li><a tabindex="-1" href="/Page/Event.aspx">Events</a></li>
                        </ul>
                    </li>

                    <li class="divider-vertical"></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">About <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a tabindex="-1" href="/Page/About_Me.aspx">Me</a></li>
                            <li><a tabindex="-1" href="/Page/About_Site.aspx">This site</a></li>
                            <li class="divider"></li>
                            <li><a tabindex="-1" href="http://lab-sticc.fr/" target="_blank">Lab-STICC</a></li>
                            <li><a tabindex="-1" href="http://univ-brest.fr/" target="_blank">UBO</a></li>
                        </ul>
                    </li>

                </ul>
                <form class="navbar-form navbar-left" role="search">
                    <div class="form-group">
                        <input type="text" class="form-control" placeholder="Search">
                    </div>

                    <div class="form-group" style="margin-left: 100px">
                        <select class="form-control" style="width: 200px" id="slQuicklinks">
                            <option>Quick links</option>
                            <option value="http://beru.univ-brest.fr/~singhoff/cheddar/">Cheddar project</option>
                        </select>
                    </div>
                </form>
            </div>
        </div>
        <!-- /.navbar-collapse -->
    </nav>
</div>
