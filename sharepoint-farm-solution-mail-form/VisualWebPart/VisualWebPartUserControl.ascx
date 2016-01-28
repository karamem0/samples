<%@ assembly name="$SharePoint.Project.AssemblyFullName$" %>
<%@ assembly name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ import namespace="Microsoft.SharePoint" %>
<%@ register tagprefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ register tagprefix="sharepoint" namespace="Microsoft.SharePoint.WebControls" assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ register tagprefix="WebPartPages" namespace="Microsoft.SharePoint.WebPartPages" assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ control language="C#" autoeventwireup="true" codebehind="VisualWebPartUserControl.ascx.cs" inherits="SampleApplication.VisualWebPartUserControl" %>

<div style="width: 400px;">
    <div style="margin: 3px 0px 3px 0px;">
        <label for="ToPeopleEditor" runat="server">宛先:</label>
        <sharepoint:peopleeditor id="ToPeopleEditor" allowempty="false" validatorenabled="true" isclaimsdisabled="True" multiselect="false" runat="server" />
    </div>
    <div style="margin: 0px 0px 3px 0px;">
        <label for="SubjectTextBox" runat="server">件名:</label>
        <asp:textbox id="SubjectTextBox" cssclass="ms-input" textmode="SingleLine" width="100%" runat="server" />
        <asp:requiredfieldvalidator controltovalidate="SubjectTextBox" enableclientscript="false" errormessage="この必須フィールドに値を指定してください。" runat="server" />
    </div>
    <div style="margin: 0px 0px 3px 0px;">
        <label for="BodyTextBox" runat="server">本文:</label>
        <asp:textbox id="BodyTextBox" cssclass="ms-input" textmode="MultiLine" width="100%" runat="server" />
        <asp:requiredfieldvalidator controltovalidate="BodyTextBox" enableclientscript="false" errormessage="この必須フィールドに値を指定してください。" runat="server" />
    </div>
    <div style="margin: 0px 0px 3px 0px;">
        <asp:button id="SubmitButton" causesvalidation="true" text="送信" onclick="SubmitButton_Click" runat="server" />
    </div>
</div>
