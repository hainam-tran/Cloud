<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/FrontEnd.Master" AutoEventWireup="true" CodeBehind="CV.aspx.cs" Inherits="Website.Cloud.Page.CV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Curriculum Vitae</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>Curriculum Vitae</h2>
    <ul>
        <li>Firstname: Hai Nam</li>
        <li>Lastname: Tran</li>
        <li>Email: hai-nam.tran@univ-brest.fr </li>
        <li>Website: <a href="http://namtran.apphb.com">http://namtran.apphb.com </a></li>
        <li>Address: Université de Bretagne Occidentale, UFR Sciences et Techniques, Département Informatique<br />
            20 avenue Le Gorgeu, C.S. 93837 - BP 809, 29238 Brest Cedex 3
        </li>
        <hr />
        <b>PhD thesis: Real time scheduling and memory hiearchy</b>
        <li>---</li>
        <hr />
        <b>Education</b>
        <li>Since 2013: PhD Student at Lab-STICC, University of Western Brittany</li>
        <li>2013: Master degree from INP Toulouse and University of Science and Technology of Hanoi</li>
        <li>2011: Bachelor degree from University of Greenwich</li>
        <li>2009: Higher Diploma of Software Engineering  from Aptech</li>
        <hr />
        <b>Research Activities</b>
        <li><i>2013 - Real time scheduling and memory hierachy </i>: PhD thesis.</li>
        <li><i>2012 - Design and program industrial robot </i>: a 6 month internship at Thanh Do university, worked with ATmega64 processor,
            the objective is assebmling and programming a path finding robot which can pick up stuff.
        </li>
        <li><i>2012 - Trident engine </i>: the purpose of this project is creating a core engine that can be used for different types of 
            content management system (CMS). The engine is based on Microsoft .Net framework, the Front-End prototype is based on ASP.Net technology.
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBar" runat="server">
</asp:Content>
