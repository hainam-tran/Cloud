<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarLoader.ascx.cs"
    Inherits="Website.Cloud.Control.PageComponent.NavBarLoader" %>
<script type="text/javascript">
    $(document).ready(function () {
        var myList = [];
        myList.push(document.getElementById('slTools'));
        myList.push(document.getElementById('slQuicklinks'));
        myList.push(document.getElementById('slFavs'));
        for (var i = 0; i < myList.length; i++)
            myList[i].onchange = function () {
                if (this.options[this.selectedIndex].value != this.options[this.selectedIndex].text) {
                    window.open(this.options[this.selectedIndex].value);
                }
            };
    });
</script>
<div class="navbar navbar-fixed-top">
    <div class="navbar-inner">
        <div class="container">
            <div class="row">
                <div class="offset1">
                    <ul class="nav">
                        <li><a href="#"><b>Quick links</b></a>
                            <select id="slQuicklinks">
                                <option>Please Select</option>
                                <option value="http://beru.univ-brest.fr/~singhoff/cheddar/">Cheddar project</option>
                            </select>
                        </li>
                        <li class="divider-vertical"></li>
                        <li><a href="#"><b>Useful Tools</b></a>
                            <select id="slTools">
                                <option>Please Select</option>
                                <option value="http://www.guidgenerator.com/">GUID Generator</option>
                                <option value="http://www.javascripter.net/faq/rgbtohex.htm">RGB Converter</option>
                            </select>
                        </li>
                        <li class="divider-vertical"></li>
                        <li><a href="#"><b>My Favorites</b></a>
                            <select id="slFavs">
                                <option>Please Select</option>
                                <option value="http://www.phdcomics.com/">PhD Comics</option>
                                <option value="http://thedailywtf.com/">TheDailyWtf</option>
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
