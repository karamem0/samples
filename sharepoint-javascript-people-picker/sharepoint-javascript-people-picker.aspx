<%@ Page language="C#" masterpagefile="~masterurl/default.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=16.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %>
<%@ Register tagprefix="SharePoint" namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register tagprefix="Utilities" namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register tagprefix="WebPartPages" namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.2.4.min.js"></script>
    <script type="text/javascript">
        (function () {

            var title = $('title').text();

            $(document).ready(function () {
                $('#pickerButton').on('click', showPickerDialog);
            });

            function showPickerDialog(sender) {
                var dialogUrl = '<asp:Literal runat="server" text="<% $SPUrl:~site/_layouts/15/Picker.aspx %>"></asp:Literal>';
                var dialogParam = {
                    MultiSelect: 'False',
                    CustomProperty: 'User;;15;;;False',
                    DialogImage: '/_layouts/15/images/ppeople.gif',
                    PickerDialogType: 'Microsoft.SharePoint.WebControls.PeoplePickerDialog, Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c',
                    ForceClaims: 'False',
                    DisableClaims: 'False',
                    EnabledClaimProviders: '',
                    EntitySeparator: ';'
                };
                var dialogWidth = 575;
                var dialogHeight = 500;
                var options = {
                    title: "ユーザーの選択",
                    width: dialogWidth,
                    height: dialogHeight,
                    resizeable: true,
                    url: dialogUrl + '?' + $.param(dialogParam),
                    dialogReturnValueCallback: function (dialogResult, returnValue) {
                        if (dialogResult == SP.UI.DialogResult.OK) {
                            var entity = $(returnValue).find('Entity');
                            $('#pickerLoginName').text(entity.attr('Key'));
                            $('#pickerDisplayName').text(entity.attr('DisplayText'));
                            $('#pickerDescription').text(entity.attr('Description'));
                        }
                        $('title').text(title);
                    }
                };
                EnsureScriptParams("SP.UI.Dialog.js", "SP.UI.ModalDialog.showModalDialog", options);
            }

        })();
    </script>
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderSearchArea" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <div id="container">
        <div>
            <input id="pickerButton" type="button" value="ユーザーの選択" />
        </div>
        <div id="pickerLoginName"></div>
        <div id="pickerDisplayName"></div>
        <div id="pickerDescription"></div>
    </div>
</asp:Content>
