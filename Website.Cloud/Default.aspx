<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.Cloud.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc" Src="~/Control/CssLoader.ascx" TagName="CssLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/JavaScriptLoader.ascx" TagName="JavaScriptLoader" %>
<%@ Register TagPrefix="uc" Src="~/Control/PageComponent/NavBarLoader.ascx" TagName="NavBarLoader" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tran Hai Nam's home page</title>
    <%--//Include Css and Java Scripts
        ================================================--%>
    <uc:CssLoader ID="CssLoader" runat="server"></uc:CssLoader>
    <uc:JavaScriptLoader ID="JavaScriptLoader" runat="server"></uc:JavaScriptLoader>
</head>
<body>
    <%--//Navigation bar
     ================================================--%>
    <uc:NavBarLoader ID="NavBarLoader" runat="server"></uc:NavBarLoader>
    <form id="ArtnmanForm" runat="server">


        <%--//Page Content
        ================================================--%>
        <div class="container">
            <%--<div class="row">
                <div class="offset1 padding-default">
                </div>
            </div>--%>
            <div class="row">
                <div class="navbar span10 offset1" style="margin-bottom: 0">
                    <%--//Menu bar
                    ================================================--%>
                    <%--<uc:MenuBarLoader ID="MenuBarLoader" runat="server"></uc:MenuBarLoader>--%>
                    <br />
                    <%--//Hero unit
                    ================================================--%>
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" style="height: 250px">
                            <div class="item active">
                                <img src="/Upload/Image/Misc/herounit1.jpg" alt="...">
                                <div class="carousel-caption">
                                </div>
                            </div>
                            <div class="item">
                                <img src="/Upload/Image/Misc/herounit3.jpg" alt="...">
                                <div class="carousel-caption">
                                </div>
                            </div>

                        </div>

                        <!-- Controls -->
                        <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                        </a>
                    </div>
                </div>
            </div>
            <%--//Blocks
            ================================================--%>
            <div class="row">
                <div class="span10 offset1">
                    <div class="row ">
                        <div class="span10" style="text-align: justify">
                            <h2>Tran Hai Nam</h2>
                            <ul>
                                <li><b>PhD student in computer sciences</b></li>
                                Lab-STICC, University of Western Brittany, Brest, France

                                <hr />

                                <li>Email: hai-nam [dot] tran [at] univ-brest [dot] fr </li>
                                <li>Web Page: <a href="http://namtran.apphb.com">http://namtran.apphb.com </a></li>
                                <li>Postal Address: Université de Bretagne Occidentale, UFR Sciences et Techniques, Département Informatique<br />
                                    20 avenue Le Gorgeu, C.S. 93837 - BP 809, 29238 Brest Cedex 3
                                </li>
                                <hr />
                                <h4>Research activites</h4>
                                <li>
                                <b>PhD thesis: Real time scheduling and memory hiearchy</b><br/>
                               
                                Analyse the effect of memory hiearchy with real time system is the objectives of my research. 
                                A real-time system is called critical when its dysfunction could lead to serious damages upon persons or environment. 
                                The validity and preditability of such systems is crucial
                                    <br />
                                    <br />
                                    Nowadays, the memory hiearchy is still a part that makes real time system unpredictable.
                                    A simple example can be cache memory.
                                    On the one hand, cache provides a performance boost to the system, narrows the gap between
                                    processor and memory speed. On the other hand, it creates the cache related pre-emption delay - the
                                    additional time to reload data evicted by the pre-empt task.
                                    <br />
                                    <br />
                                    This work takes place within the <a href="http://beru.univ-brest.fr/~singhoff/cheddar/">Cheddar</a> project, started in semptember 2000 by professor 
                                    <a href="http://beru.univ-brest.fr/~singhoff/">Frank Singhoff.</a>

                                </li>
                                <br/>
                                <li><b>Application domain</b>
                                    <ul>
                                        <li>Embedded / real-time systems</li>
                                        <li>Real-time scheduling theory</li>
                                    </ul>
                                </li>
                                <br/>
                                <li><b>Research Interest</b>
                                    <ul>
                                        <li>Real time systems</li>
                                        <li>Distrubuted computing</li>
                                        <li>Object oriented programming languages</li>
                                        <li>Modelling languages and design patterns</li>
                                        <li>Software engineering</li>
                                    </ul>
                                </li>
                                <br/>
                                <li>A short resume is avalaible <a href="/Page/CV.aspx">here</a>
                                </li>

                                <hr />

                                <li>Keywords: tran hai nam, ubo, cheddar project, real-time systems, real-time scheduling</li>

                            </ul>
                        </div>
                    </div>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="span8 offset1">
                    <%-- <div class="row">
                        <div class="span4">
                            <h2>Video</h2>
                        </div>
                    </div>
                    <div class="row ">
                        <div class="span4">
                            <iframe width="370" height="250" src="http://www.youtube.com/embed/kBqWtdMpies" frameborder="0"></iframe>
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
                    <hr />--%>
                    <div class="row">
                        <div class="span4">
                            <h2>Gallery</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span4 text-center">
                            <img src="/Upload/Image/Misc/img-test.png" width="350px" />
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
                    <h2>Links</h2>
                    <p>
                        <ul>
                            <li><a href="http://beru.univ-brest.fr/~singhoff/cheddar/" target="_blank">The CHEDDAR
                            project</a></li>
                            <li><a href="https://www.facebook.com/groups/357576524280743/" target="_blank">Vietnamese
                            students in Brest</a></li>
                        </ul>
                    </p>
                    <h2>Blog</h2>
                    <ul>
                        <li><a href="http://artnman.blogspot.fr/2013/06/problem-with-naming-convention-of-me.html"
                            target="_blank">Problem with naming convention of me.</a></li>
                        <li><a href="http://artnman.blogspot.fr/2013/06/things-happen-when-you-stay-far-from.html"
                            target="_blank">Things happen when you live abroad.</a></li>

                    </ul>
                    <%--<p align="center">
                        <a href="http://artnman.blogspot.com" target="_blank" class="btn">View more »</a>
                    </p>--%>
                    <%--                <h2>
                    Connect</h2>
                <div style="text-align: center">
                    <uc:SocialNetworkLoader ID="SocialNetworkLoader" runat="server"></uc:SocialNetworkLoader>
                </div>--%>
                </div>
            </div>

            <%--//Footer
            ================================================--%>
            <div class="row">
                <div class="span10 offset1">
                    <hr />
                </div>
                <div class="span8 offset1">
                    <a href="http://en.wikipedia.org/wiki/Copyright">© NamTran</a>
                </div>
                <div class="span2" style="text-align: right">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
