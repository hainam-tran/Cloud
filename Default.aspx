<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.Cloud.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc" Src="~/Control/CssLoader.ascx" TagName="CssLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/JavaScriptLoader.ascx" TagName="JavaScriptLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/NavBarLoader.ascx" TagName="NavBarLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/SocialNetworkLoader.ascx"
    TagName="SocialNetworkLoader" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inspiration</title>
    <%--//Include Css and Java Scripts
        ================================================--%>
    <uc:CssLoader ID="CssLoader" runat="server"></uc:CssLoader>
    <uc:JavaScriptLoader ID="JavaScriptLoader" runat="server"></uc:JavaScriptLoader>
</head>
<body>
    <form id="ArtnmanForm" runat="server">
    <%--//Navigation bar
        ================================================--%>
    <uc:NavBarLoader ID="NavBarLoader" runat="server"></uc:NavBarLoader>
    <%--//Page Content
        ================================================--%>
    <div class="container">
        <div class="row">
            <div class="offset1 padding-default">
                <img src="Upload/Image/logo-greenwich.gif" />
            </div>
        </div>
        <div class="row">
            <div class="navbar span10 offset1" style="margin-bottom: 0">
                <%--//Nav bar
                    ================================================--%>
                <div class="navbar-inner">
                    <ul class="nav">
                        <li class="active"><a href="#">Home</a></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Study
                            at Greenwich <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a tabindex="-1" href="#">Programmes</a></li>
                                <li><a tabindex="-1" href="#">Accomodation</a></li>
                                <li><a tabindex="-1" href="#">Fees & finance</a></li>
                                <li><a tabindex="-1" href="#">How to apply</a></li>
                                <li class="divider"></li>
                                <li><a tabindex="-1" href="#">Student support & services</a></li>
                                <li><a tabindex="-1" href="#">Open days</a></li>
                                <li><a tabindex="-1" href="#">Ask Greenwich</a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Students
                            <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a tabindex="-1" href="#">Prospective student</a></li>
                                <li><a tabindex="-1" href="#">New students</a></li>
                                <li class="divider"></li>
                                <li><a tabindex="-1" href="#">International students</a></li>
                                <li><a tabindex="-1" href="#">Current students</a></li>
                                <li><a tabindex="-1" href="#">Mature students</a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Alumni
                            <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a tabindex="-1" href="#">Staying in touch</a></li>
                                <li><a tabindex="-1" href="#">Our alumni</a></li>
                                <li class="divider"></li>
                                <li><a tabindex="-1" href="#">Events and reunions</a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">About
                            Greenwich <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a tabindex="-1" href="#">News</a></li>
                                <li><a tabindex="-1" href="#">Travel & transport</a></li>
                                <li><a tabindex="-1" href="#">Our campuses</a></li>
                                <li class="divider"></li>
                                <li><a tabindex="-1" href="#">Contact us</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <br />
                <%--//Hero unit
                    ================================================--%>
                <div id="myCarousel" class="carousel slide" style="margin-bottom: 0">
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                    </ol>
                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <div class="active item">
                            <div class="hero-unit">
                                <h1 class="padding-left-20">
                                    Heading</h1>
                                <p class="padding-left-20">
                                    Tagline</p>
                                <p class="padding-left-20">
                                    <a class="btn btn-primary btn-large">Learn more </a>
                                </p>
                            </div>
                        </div>
                        <div class="item">
                            <div class="hero-unit">
                                <h1 class="padding-left-20">
                                    Heading</h1>
                                <p class="padding-left-20">
                                    Tagline</p>
                                <p class="padding-left-20">
                                    <a class="btn btn-primary btn-large">Learn more </a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <!-- Carousel nav -->
                    <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                    <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
                </div>
            </div>
        </div>
        <%--//Blocks
            ================================================--%>
        <div class="row">
            <div class="span2 offset1">
                <h2>
                    Links</h2>
                <p>
                    Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus
                    commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.
                    Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.
                </p>
                <p>
                    <a class="btn" href="#">View details »</a></p>
            </div>
            <div class="span6">
                <div class="row">
                    <div class="span4">
                        <h2>
                            Video</h2>
                    </div>
                </div>
                <div class="row ">
                    <div class="span4">
                        <iframe width="370" height="250" src="http://www.youtube.com/embed/NW6Pmwf34DA" frameborder="0"
                            allowfullscreen></iframe>
                    </div>
                    <div class="span2">
                        Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus
                        commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit a
                        <br />
                        <br />
                        <a class="btn" href="#">View details »</a>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="span4">
                        <h2>
                            Images</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="span4">
                        <img src="http://www2.gre.ac.uk/__data/assets/image/0009/689058/great-feature-1.jpg" />
                    </div>
                    <div class="span2">
                        Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus
                        commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit a
                        <br />
                        <br />
                        <a class="btn" href="#">View details »</a>
                    </div>
                </div>
            </div>
            <div class="span2">
                <h2>
                    Heading</h2>
                <p>
                    met risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.
                </p>
                <p>
                    <a class="btn" href="#">View details »</a></p>
            </div>
        </div>
        <%--//Footer
            ================================================--%>
        <div class="row">
            <div class="span10 offset1">
                <hr />
            </div>
            <div class="span8 offset1">
                <a href="http://www.gre.ac.uk/copyright">© University of Greenwich</a>
            </div>
            <div class="span2" style="text-align: right">
                <uc:SocialNetworkLoader ID="SocialNetworkLoader" runat="server"></uc:SocialNetworkLoader>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
