<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBarLoader.ascx.cs"
    Inherits="Website.Cloud.Control.PageComponent.MenuBarLoader" %>
<div class="navbar-inner">
    <ul class="nav">
        <li class="active"><a href="#">Home</a></li>
        <li><a href="#">A short CV</a></li>
        <li><a href="#">Publication</a></li>

        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">About<b
            class="caret"></b></a>
            <ul class="dropdown-menu">
                <li><a tabindex="-1" href="#">Me</a></li>
                <li><a tabindex="-1" href="#">This site</a></li>
                <li class="divider"></li>
                <li><a tabindex="-1" href="http://lab-sticc.fr/" target="_blank">Lab-STICC</a></li>
            </ul>
        </li>
        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Misc<b
            class="caret"></b></a>
            <ul class="dropdown-menu">
                <li><a tabindex="-1" href="http://500px.com/ArtnmaN" target="_blank">Gallery</a></li>
                <li><a tabindex="-1" href="http://artnman.blogspot.com" target="_blank">Blog</a></li>
            </ul>
        </li>
    </ul>
</div>
