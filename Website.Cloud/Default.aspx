<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.Cloud.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc" Src="~/Control/CssLoader.ascx" TagName="CssLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/JavaScriptLoader.ascx" TagName="JavaScriptLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/NavBarLoader.ascx" TagName="NavBarLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/MenuBarLoader.ascx" TagName="MenuBarLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/SocialNetworkLoader.ascx"
    TagName="SocialNetworkLoader" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tran Hai Nam's personal cloud</title>
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
                <%--<img src="Upload/Image/Logo/logo.png"/>--%>
            </div>
        </div>
        <div class="row">
            <div class="navbar span10 offset1" style="margin-bottom: 0">
                <%--//Menu bar
                    ================================================--%>
                <uc:MenuBarLoader ID="MenuBarLoader" runat="server"></uc:MenuBarLoader>
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
                            <div class="hero-unit hero-unit-custom" style="background-image: url(/Upload/Image/Misc/herounit1.jpg);">
                                <%--<h1 class="padding-left-20">
                                </h1>
                                <p class="padding-left-20">
                                    Pont de Albert Loupe</p>
                                <p class="padding-left-20">
                                    <a class="btn btn-primary btn-large">Learn more </a>
                                </p>--%>
                            </div>
                        </div>
                        <div class="item">
                            <div class="hero-unit hero-unit-custom" style="background-image: url(/Upload/Image/Misc/herounit3.jpg);">
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
            <div class="span8 offset1">
                <div class="row">
                    <div class="span4">
                        <h2>
                            Hello World - ! - !!!</h2>
                    </div>
                </div>
                <div class="row ">
                    <div class="span8">
                        <ul>
                            <li>Trần Hải Nam (Full Vietnamese name)</li>
                            <li>Intern at Lab-STICC, University of Western Brittany, Brest, France</li>
                            <li>Research Interest:
                                <ul>
                                    <li>Distrubuted Computing</li>
                                    <li>Real time systems</li>
                                    <li>Object oriented programming languages</li>
                                </ul>
                            </li>
                            <hr />
                            <li>Contact: namth@outlook.com </li>
                            <hr />
                            <li>I'm a researcher and web developer. Even though I have stopped to work as a web
                                developer for a long time, I still want to practice. I made this website firstly
                                for people can contact me. Secondly, I also experience knowledge about web design.
                                <br />
                                <br />
                                This site is under construction. There are many things not working now. I'm sorry
                                for that. </li>
                        </ul>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="span4">
                        <h2>
                            Video</h2>
                    </div>
                </div>
                <div class="row ">
                    <div class="span4">
                        <iframe width="370" height="250" src="http://www.youtube.com/embed/kBqWtdMpies" frameborder="0"
                            allowfullscreen></iframe>
                    </div>
                    <div class="span4">
                        A song for the guy who first time goes abroad.
                        <br />
                        <br />
                        The video gallery will be upgraded later, later than the picture gallery.
                        <br />
                        <br />
                        <a class="btn" href="#">View details »</a>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="span4">
                        <h2>
                            Gallery</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="span4">
                        <img src="/Upload/Image/Misc/img-test.png" />
                    </div>
                    <div class="span4">
                        I'm an amateur photographer. I take picture of people and things around my life.
                        At the beginning, I'm intended to design a gallery module but I does not have time.
                        It will be upgraded in the future and I will upload my photos there.
                        <br />
                        <br />
                        For the time being, you can view my photos at <a href="http://500px.com/ArtnmaN"
                            target="_blank">500px</a>
                        <br />
                        <br />
                        <a class="btn btn-info" href="http://500px.com/ArtnmaN" target="_blank">My gallery »</a>
                    </div>
                </div>
            </div>
            <div class="span2">
                <h2>
                    Links</h2>
                <p>
                    <ul>
                        <li><a href="http://beru.univ-brest.fr/~singhoff/cheddar/" target="_blank">The CHEDDAR
                            project</a></li>
                        <li><a href="https://www.facebook.com/groups/357576524280743/" target="_blank">Vietnamese
                            students in Brest</a></li>
                    </ul>
                </p>
                <h2>
                    Blog</h2>
                <ul>
                    <li><a href="http://artnman.blogspot.fr/2013/06/things-happen-when-you-stay-far-from.html"
                        target="_blank">Things happen when you live abroad.</a></li>
                </ul>
                <p align="center">
                    <a href="http://artnman.blogspot.com" target="_blank" class="btn">View more »</a>
                </p>
                <h2>
                    Connect</h2>
                <div style="text-align: center">
                    <uc:SocialNetworkLoader ID="SocialNetworkLoader" runat="server"></uc:SocialNetworkLoader>
                </div>
            </div>
        </div>
        <%--//Footer
            ================================================--%>
        <div class="row">
            <div class="span10 offset1">
                <hr />
            </div>
            <div class="span8 offset1">
                <a href="http://en.wikipedia.org/wiki/Copyright">© NamTH</a>
            </div>
            <div class="span2" style="text-align: right">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
