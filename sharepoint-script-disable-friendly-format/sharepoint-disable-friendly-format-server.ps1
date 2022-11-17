Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$url = "{{siteurl}}"

$web = Get-SPWeb $url
for ($i = 0; $i -lt $web.Lists.Count; $i++) {
    $list = $web.Lists[$i]
    $field = $list.Fields["Created"]
    $field = $field -as [Microsoft.SharePoint.SPFieldDateTime]
    if ($field -isnot $null) {
        $field.FriendlyDisplayFormat = [Microsoft.SharePoint.SPDateTimeFieldFriendlyFormatType]::Disabled
        $field.Update()
    }
    $field = $list.Fields["Modified"]
    $field = $field -as [Microsoft.SharePoint.SPFieldDateTime]
    if ($field -isnot $null) {
        $field.FriendlyDisplayFormat = [Microsoft.SharePoint.SPDateTimeFieldFriendlyFormatType]::Disabled
        $field.Update()
    }
}
