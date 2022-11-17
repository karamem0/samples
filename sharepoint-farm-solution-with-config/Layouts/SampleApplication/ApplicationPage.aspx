<%@ assembly name="$SharePoint.Project.AssemblyFullName$" %>
<%@ assembly name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import namespace="System.Configuration" %>
<%@ import namespace="Microsoft.SharePoint" %>
<%@ import namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ import namespace="Microsoft.SharePoint.Utilities" %>
<%@ register tagprefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ page language="C#" autoeventwireup="true" codebehind="ApplicationPage1.aspx.cs" inherits="SampleApplication.ApplicationPage1" dynamicmasterpagefile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <h1><%# ConfigurationManager.AppSettings["Message"] %></h1>
</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
    アプリケーション ページ
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
    マイ アプリケーション ページ
</asp:content>
