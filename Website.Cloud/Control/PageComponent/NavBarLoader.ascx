<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarLoader.ascx.cs"
    Inherits="Website.Cloud.Control.PageComponent.NavBarLoader" %>
<div class="navbar navbar-fixed-top">
    <div class="navbar-inner">
        <div class="container">
            <div class="row">
                <div class="offset1">
                    <ul class="nav">
                        <li><a href="#"><b>Quick links</b></a>
                            <select>
                                <option>Please Select</option>
                                <option>A short CV</option>
                                <option>Current Project</option>
                            </select>
                        </li>
                        <li class="divider-vertical"></li>
                        <li><a href="#"><b>Useful Tools</b></a>
                            <select>
                                <option>Please Select</option>
                                <option>GUID Generator</option>
                                <option>RGB Converter</option>
                            </select>
                        </li>
                        <li class="divider-vertical"></li>
                        <li><a href="#"><b>My Favorites</b></a>
                            <select>
                                <option>Please Select</option>
                                <option>TheDailyWtf</option>
                                <option>FML</option>
                                <option>9gag</option>
                            </select>
                        </li>
                        <li class="divider-vertical"></li>
                    </ul>
                </div>
                <div class="span1" style="padding-top: 20px">
                    <div class="nav-collapse">
                        <div class="navbar-search">
                            <input type="text" class="search-query span2" placeholder="Search">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
