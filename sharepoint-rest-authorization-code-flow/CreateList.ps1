[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SharePoint.Client")
[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SharePoint.Client.Runtime")

$SiteUrl = "<SiteUrl>"
$UserName = "<UserName>"
$Password = "<Password>"

$credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($UserName, (ConvertTo-SecureString $Password -AsPlainText -Force))

$context = New-Object Microsoft.SharePoint.Client.ClientContext($SiteUrl)
$context.Credentials = $credentials

$creation = New-Object Microsoft.SharePoint.Client.ListCreationInformation
$creation.TemplateType = [int][Microsoft.SharePoint.Client.ListTemplateType]::GenericList
$creation.Title = "TimeRecorder"
$list = $context.Web.Lists.Add($creation)
$context.ExecuteQuery()
$list.Title = "タイム レコーダー"
$list.Update()
$context.ExecuteQuery()

$fieldXml = "<Field Type='DateTime' DisplayName='Timestamp' Format='DateTime' Name='Timestamp'/>" 
$field = $list.Fields.AddFieldAsXml($fieldXml, $true, [Microsoft.SharePoint.Client.AddFieldOptions]::AddFieldToDefaultView)
$context.ExecuteQuery()
$field.Title = "タイムスタンプ"
$field.Update()
$context.ExecuteQuery()
