[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SharePoint.Client")
[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SharePoint.Client.Runtime")

$url = "{{siteurl}}"
$username = "{{userid}}"
$password = "{{password}}"

$password = ConvertTo-SecureString $password -AsPlainText -Force
$credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($username, $password)
$context = New-Object Microsoft.SharePoint.Client.ClientContext($url)
$context.Credentials = $credentials

$web = $context.Web
$context.Load($web.Lists)
$context.ExecuteQuery()

foreach ($list in $web.Lists) {
    $context.Load($list.Fields)
    $context.ExecuteQuery()

    $field = $list.Fields.GetByInternalNameOrTitle("Created")
    $field = New-Object Microsoft.SharePoint.Client.FieldDateTime($context, $field.Path)
    $context.Load($field)
    $context.ExecuteQuery()
    $field.FriendlyDisplayFormat = [Microsoft.SharePoint.Client.DateTimeFieldFriendlyFormatType]::Disabled
    $field.Update()
    $context.ExecuteQuery()

    $field = $list.Fields.GetByInternalNameOrTitle("Modified")
    $field = New-Object Microsoft.SharePoint.Client.FieldDateTime($context, $field.Path)
    $context.Load($field)
    $context.ExecuteQuery()
    $field.FriendlyDisplayFormat = [Microsoft.SharePoint.Client.DateTimeFieldFriendlyFormatType]::Disabled
    $field.Update()
    $context.ExecuteQuery()
}
